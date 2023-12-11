
    public class GeoLocalizacao
    {
        protected GeoLocalizacao() { }

        public GeoLocalizacao(string latitude, string longetude, string altura)
        {
            Latitude = latitude;
            Longetude = longetude;
            Altura = altura;
        }

        public string Latitude { get; set; }
        public string Longetude { get; set; }
        public string Altura { get; set; }

    }

