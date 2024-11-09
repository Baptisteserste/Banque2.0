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
class CurrentAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public double CreditLine { get; set; }
    public Personne Owner { get; set; }

    public CurrentAccount(string number, double creditLine, Personne owner)
    {
        Number = number;
        Balance = 0.0;
        CreditLine = creditLine;
        Owner = owner;
    }

    public void Withdraw(double amount)
    {
        if (Balance - amount >= -CreditLine)
        {
            Balance -= amount;
            Console.WriteLine($"Retrait de {amount} réussi. Nouveau solde : {Balance}");
        }
        else
        {
            Console.WriteLine("Retrait refusé : la limite de crédit est dépassée.");
        }
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        Console.WriteLine($"Dépôt de {amount} réussi. Nouveau solde : {Balance}");
    }
}
class SavingsAccount
{
     public string Number { get; set; }
    public double Balance { get; private set; }
    public DateTime DateLastWithdraw { get; set; }
    public Personne Owner { get; set; }

    public SavingsAccount(string number, Personne owner)
    {
        Number = number;
        Balance = 0.0; 
        Owner = owner;
        DateLastWithdraw = DateTime.MinValue; 
    }
}

class Bank
{
    public Dictionary<string, CurrentAccount> Accounts { get; private set; }
    public string Name { get; set; }

    public Bank(string name)
    {
        Name = name;
        Accounts = new Dictionary<string, CurrentAccount>();
    }

    public void AddAccount(CurrentAccount account)
    {
        if (!Accounts.ContainsKey(account.Number))
        {
            Accounts[account.Number] = account;
            Console.WriteLine($"Compte {account.Number} ajouté.");
        }
        else
        {
            Console.WriteLine("Le compte existe déjà.");
        }
    }

    public void DeleteAccount(string number)
    {
        if (Accounts.Remove(number))
        {
            Console.WriteLine($"Compte {number} supprimé.");
        }
        else
        {
            Console.WriteLine("Compte non trouvé.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Création d'une personne
        Personne proprietaire = new Personne("Dupont", "Jean", 30, 180);

        // Création d'un compte courant
        CurrentAccount compte = new CurrentAccount("123456", 1000.0, proprietaire);

        // Dépôt et retrait
        compte.Deposit(500.0);
        compte.Withdraw(200.0);
        compte.Withdraw(1500.0); 

        // Affichage des informations sur le compte
        Console.WriteLine($"Propriétaire du compte : {compte.Owner.Prenom} {compte.Owner.Nom}");
        Console.WriteLine($"Solde actuel : {compte.Balance}");
    }
}
