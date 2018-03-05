using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace CG.XmlSerialization.Example
{
    class Program
    {
        static void qweMain(string[] args)
        {
            // Load the patients.xml and display the contents
            foreach (var profile in Patients.Load(GetFullPathName("Patients.xml")).Profiles)
            {
                Display(profile);
            }
        }

        /// <summary>
        /// Given a file, retrieve the full path name (in this case files are located in the same folder as the application)
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <returns></returns>
        private static string GetFullPathName(string xmlFile)
        {
            string appFolder = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

            return Path.Combine(appFolder.Substring(0, appFolder.LastIndexOf('\\')), xmlFile);
        }

        /// <summary>
        /// Writes the profile detail to the console
        /// </summary>
        /// <param name="profile"></param>
        private static void Display(Profile profile)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Profile - Id: {0}\n", profile.Id);
            sb.AppendFormat("  Clinic Dr: {0}\n", profile.ClinicDr);
            sb.AppendFormat("  Clinic Date: {0}\n", profile.ClinicDate);
            sb.AppendFormat("  Patient No: {0}\n", profile.PatNo);
            sb.AppendFormat("  ForeName: {0}\n", profile.ForeName);
            sb.AppendFormat("  SurName: {0}\n", profile.SurName);

            sb.AppendLine(String.Empty);
            Console.WriteLine(sb.ToString());
        }
    }

    /// <summary>
    /// Represents the top level Patients xml item.
    /// Contains a static method that loads the file and turns it into a Patients instance
    /// </summary>
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "patients", Namespace = "", IsNullable = false)]
    public class Patients
    {
        public static Patients Load(string xmlFile)
        {
            var serializer = new XmlSerializer(typeof(Patients));

            using (var reader = XmlReader.Create(xmlFile))
            {
                return (Patients)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Contains a list of Profile nodes
        /// </summary>
        [XmlElement("profile")]
        public Profile[] Profiles
        {
            get { return _profiles.ToArray(); }

            set
            {
                if (_profiles == null) { _profiles = new List<Profile>(); }

                if (value != null) { _profiles.AddRange(value); }
            }
        }

        private List<Profile> _profiles = new List<Profile>();

    }

    /// <summary>
    /// Represents a single profile
    /// </summary>
    public class Profile
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("ClinicDr")]
        public string ClinicDr { get; set; }

        [XmlElement("ClinicDate")]
        public string ClinicDate { get; set; }

        [XmlElement("PatNo")]
        public string PatNo { get; set; }

        [XmlElement("Forename")]
        public string ForeName { get; set; }

        [XmlElement("Surname")]
        public string SurName { get; set; }
    }
}