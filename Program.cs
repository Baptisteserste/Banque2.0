class Personne
{
    public string Nom { get; private set; }
    public string Prenom { get; private set; }
    public int Age { get; private set; }
    public int Taille { get; private set; }

    public Personne(string nom, string prenom, int age, int taille)
    {
        Nom = nom;
        Prenom = prenom;
        Age = age;
        Taille = taille;
    }
}