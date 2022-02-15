namespace LeGrandRestaurant.Test
{
    internal class ServeurBuilder
    {
  
        
     
        private string? _nom;
        // crée une isntance du serveur
        public Serveur Build() => _nom is null ? new Serveur() : new Serveur(_nom);
        
        // crée le stub  
        public static Serveur Stub = new ServeurBuilder().Build();
        
        
        
        public ServeurBuilder Nomme(string? nom)
        {
            _nom = nom;
            return this;
        }
    }
}