namespace Course.Entities {
    class Produto {

        public string Nome { get; set; }
        public double Preço { get; set; }
        public int Quantidade { get; set; }

        public Produto(string nome, double preço, int quantitade) {
            Nome = nome;
            Preço = preço;
            Quantidade = quantitade;
        }

        public double Total() {
            return Preço * Quantidade;
        }
    }
}
