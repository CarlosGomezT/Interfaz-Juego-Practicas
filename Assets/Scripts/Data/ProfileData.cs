public class ProfileData
{
    public string fileName;
    public string name;
    public string gender;
    public int gen_Value;
    public int age;
    public int img_num;
    public bool[] libros;
    public Actividades[] TotalActividades;


    public ProfileData()
    {
        this.fileName = "None.xml";
        this.name = "None";
    }

    public ProfileData(string name, string gender, int age, int gen_Value)
    {
        var index = ProfileStorage.GetProfileIndex();

        this.fileName = index.profileFileNames.Count + "_" + name.Replace(" ", "_") + ".xml";
        this.name = name;
        this.gender = gender;
        this.gen_Value = gen_Value;
        this.age = age;

    libros = new bool[7];
        for (int i = 0; i < libros.Length; i++)
        {
            libros[i] = false;
        }

        TotalActividades = new Actividades[10];
        for (int i = 0; i < TotalActividades.Length; i++)
        {
            TotalActividades[i] = new Actividades(i);
        }
    }
}
