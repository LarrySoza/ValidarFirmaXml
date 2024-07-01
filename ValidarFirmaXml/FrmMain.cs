using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ValidarFirmaXml
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnValidarXml_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML (*.xml)|*.xml";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ShowInfoXml(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        txtInfoAppendTex(ex.Message, Color.Red);
                    }
                }
            }
        }

        private void btnValidarXmlDeZip_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "ZIP (*.zip)|*.zip";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ShowInfoZipXml(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        txtInfoAppendTex(ex.Message, Color.Red);
                    }
                }
            }
        }

        private void ShowInfoXml(String path)
        {
            txtInfo.Text = String.Empty;
            var _encoding = GetXmlEncoding(File.ReadAllText(path));

            var _xml = File.ReadAllText(path, _encoding);

            txtInfoAppendTex($"Encoding: ", Color.Black);
            txtInfoAppendTex($"{_encoding}\n", Color.Blue);

            MostrarInfoXML(_xml);
        }

        private void ShowInfoZipXml(String path)
        {
            txtInfo.Text = String.Empty;
            Encoding _encoding;

            var _xml = LeerZipXml(File.ReadAllBytes(path), out _encoding);

            txtInfoAppendTex($"Encoding: ", Color.Black);
            txtInfoAppendTex($"{_encoding}\n", Color.Blue);

            MostrarInfoXML(_xml);
        }

        private void txtInfoAppendTex(string txt, Color color)
        {
            txtInfo.SelectionStart = txtInfo.TextLength;
            txtInfo.SelectionLength = 0;
            txtInfo.SelectionColor = color;
            txtInfo.AppendText(txt);
        }

        private void MostrarInfoXML(String xml)
        {
            if (VerificarFirmaXml(xml))
            {
                txtInfoAppendTex("**** XMl valido ****\n", Color.Green);
            }
            else
            {
                txtInfoAppendTex("**** Xml adulterado ****\n", Color.Red);
            }

            var _certificado = LeerCertificadoXml(xml);

            txtInfoAppendTex($"SerialNumber: ", Color.Black);
            txtInfoAppendTex($"{_certificado.SerialNumber}\n", Color.Blue);

            txtInfoAppendTex($"Subject:\n", Color.Black);
            var _InfoSubject = _certificado.Subject.Split(',');

            foreach (var item in _InfoSubject)
            {
                txtInfoAppendTex($"     {item.Trim()}\n", Color.Blue);
            }
        }

        #region Metodos lectura y validacion XML

        private static Encoding GetXmlEncoding(string xmlString)
        {
            try
            {
                using (StringReader stringReader = new StringReader(xmlString))
                {

                    var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };

                    var reader = XmlReader.Create(stringReader, settings);
                    reader.Read();

                    var encoding = reader.GetAttribute("encoding");

                    var result = Encoding.GetEncoding(encoding);
                    return result;

                }
            }
            catch
            {
                throw new Exception("Error al leer el encoding del xml");
            }
        }

        private static string LeerZipXml(byte[] bytesZip, out Encoding encoding)
        {
            var _string = string.Empty;
            encoding = null;

            using (var memRespuesta = new MemoryStream(bytesZip))
            {
                using (ZipArchive fileZip = new ZipArchive(memRespuesta, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in fileZip.Entries)
                    {
                        if (!entry.Name.ToLower().EndsWith(".xml")) continue;

                        //Leer el inicio del XMl para saber el encoding
                        using (Stream ms = entry.Open())
                        {
                            var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };

                            var reader = XmlReader.Create(ms, settings);
                            reader.Read();
                            var encodingName = reader.GetAttribute("encoding");

                            encoding = Encoding.GetEncoding(encodingName);
                        }

                        //Leer todo el contenido con el encoding correcto
                        using (Stream ms = entry.Open())
                        {
                            var responseReader = new StreamReader(ms, encoding);
                            _string = responseReader.ReadToEnd();
                        }
                    }
                }
            }

            return _string;
        }

        private static bool VerificarFirmaXml(string xmlFirmado)
        {
            // Create a new XML document.
            XmlDocument xmlDocument = new XmlDocument();

            // Format using white spaces.
            xmlDocument.PreserveWhitespace = true;

            xmlDocument.LoadXml(xmlFirmado);

            // Create a new SignedXml object and pass it
            // the XML document class.
            SignedXml signedXml = new SignedXml(xmlDocument);

            // Find the "Signature" node and create a new
            // XmlNodeList object.
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

            if (nodeList.Count == 0)
            {
                nodeList = xmlDocument.GetElementsByTagName("ds:Signature");
            }

            if (nodeList.Count == 0)
            {
                throw new Exception("Error al leer la firma del XML");
            }

            XmlElement xmlElement = (XmlElement)nodeList[0];

            #region Fix XML SUNAT

            nodeList = xmlElement.GetElementsByTagName("Proposito");

            if (nodeList.Count > 0)
            {
                xmlElement.RemoveChild(nodeList[0]);
            }

            nodeList = xmlElement.GetElementsByTagName("Revocacion");

            if (nodeList.Count > 0)
            {
                xmlElement.RemoveChild(nodeList[0]);
            }

            nodeList = xmlElement.GetElementsByTagName("TSL");

            if (nodeList.Count > 0)
            {
                xmlElement.RemoveChild(nodeList[0]);
            }

            nodeList = xmlElement.GetElementsByTagName("Expiracion");

            if (nodeList.Count > 0)
            {
                xmlElement.RemoveChild(nodeList[0]);
            }

            #endregion

            // Load the signature node.
            signedXml.LoadXml(xmlElement);

            // Check the signature and return the result.
            return signedXml.CheckSignature();
        }

        private static X509Certificate2 LeerCertificadoXml(string xmlFirmado)
        {
            // Create a new XML document.
            XmlDocument xmlDocument = new XmlDocument();

            // Format using white spaces.
            xmlDocument.PreserveWhitespace = true;

            xmlDocument.LoadXml(xmlFirmado);

            // Create a new SignedXml object and pass it
            // the XML document class.
            SignedXml signedXml = new SignedXml(xmlDocument);

            // Find the "Signature" node and create a new
            // XmlNodeList object.
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("X509Certificate");

            if (nodeList.Count == 0)
            {
                nodeList = xmlDocument.GetElementsByTagName("ds:X509Certificate");
            }

            if (nodeList.Count == 0)
            {
                throw new Exception("Error al leer el certificado del XML");
            }

            return new X509Certificate2(Convert.FromBase64String(nodeList[0].InnerText));
        }

        #endregion
    }
}
