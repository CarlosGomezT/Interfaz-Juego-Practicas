using UnityEngine;
using System.IO;
using System.Xml.Serialization;
//using UnityEditorInternal;

public static class ProfileStorage
{
    //TODOS LOS DATOS SE GUARDAN EN USER\AppData\LocalLow\DefaultCompany\Prueba de dibujo\Profiles

    public static ProfileData s_currentProfile;
    private static string s_indexPath = Application.persistentDataPath + "/Profiles/_ProfileIndex_.xml";

    public static void CreateNewGame(string profileName,string profileGender, int profileAge, int gen_val)
    {
        s_currentProfile = new ProfileData(profileName,profileGender, profileAge, gen_val);

        string profilesDirectory = Application.persistentDataPath + "/Profiles";
        if (!Directory.Exists(profilesDirectory))
        {
            Directory.CreateDirectory(profilesDirectory);
        }

        string path = Path.Combine(profilesDirectory, s_currentProfile.fileName);
        SaveFile<ProfileData>(path, s_currentProfile);

        var index = GetProfileIndex();
        index.profileFileNames.Insert(0, s_currentProfile.fileName);

        SaveFile<ProfileIndex>(s_indexPath, index);
    }

    public static ProfileData LoadProfile(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, "Profiles", fileName);
        if (File.Exists(path))
        {
            return LoadFile<ProfileData>(path);
        }
        else
        {
            Debug.LogError(" No se encontro el perfil " + fileName);
            return null;
        }
    }

    public static void StoreEditProfile(ProfileData SaveInfo)
    {
        s_currentProfile.name = SaveInfo.name;
        s_currentProfile.gender = SaveInfo.gender;
        s_currentProfile.age = SaveInfo.age;
        s_currentProfile.gen_Value = SaveInfo.gen_Value;

        var path = Path.Combine(Application.persistentDataPath, "Profiles", s_currentProfile.fileName);

        SaveFile<ProfileData>(path, s_currentProfile);
    }
    public static void DeleteProfile(string filename)
    {
        var path = Path.Combine(Application.persistentDataPath, "Profiles", filename);
        File.Delete(path);

        var index = LoadFile<ProfileIndex>(s_indexPath);
        index.profileFileNames.Remove(filename);

        SaveFile<ProfileIndex> (s_indexPath, index);
    }
    public static ProfileIndex GetProfileIndex()
    {
        if (!File.Exists(s_indexPath))
        {
            return new ProfileIndex();
        }

        return LoadFile<ProfileIndex>(s_indexPath);
    }

    public static string GetFirstIndex()
    {
        var index = GetProfileIndex();

        if (index.profileFileNames.Count == 0)
        {
            CreateNewGame("Victor", "Masculino", 10, 1);
            Debug.Log("Se creo un nuevo personaje");
        }
        index = GetProfileIndex();

        return index.profileFileNames[0];

    }
    public static bool MakeProfileFirst(int selectedIndex)
    {
        var index = GetProfileIndex();
        Debug.Log(index.profileFileNames.Count + " " + selectedIndex);
        if (selectedIndex != 0 && selectedIndex < index.profileFileNames.Count)
        {
            string selectedFileName = index.profileFileNames[selectedIndex];

            index.profileFileNames.RemoveAt(selectedIndex); 
            index.profileFileNames.Insert(0, selectedFileName);
            SaveFile(s_indexPath, index);

            return true;
        }
        else
        {
            Debug.Log("No se puede cambiar posiciones en un arreglo de solo 1 elemento.");
            return false;
        }
    }

    static void SaveFile<T>(string path, T data)
    {
        using (var profileWriter = new StreamWriter(path))
        {
            var profileSerializer = new XmlSerializer(typeof(T));
            profileSerializer.Serialize(profileWriter, data);
        }
    }

    static T LoadFile<T>(string path)
    {
        using (var profileReader = new StreamReader(path))
        {
            var serializer = new XmlSerializer(typeof(T));
            var obj = (T)serializer.Deserialize(profileReader);
            return obj;
        }
    }
}
