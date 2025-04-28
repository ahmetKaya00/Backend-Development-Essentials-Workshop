namespace basics.Models{

    public class Repository{
        private static readonly List<Bootcamp> _bootcamps = new();

        static Repository(){
            _bootcamps = new List<Bootcamp>(){
                new Bootcamp(){Id = 1, Title= "Backend Bootcamp",Description="Güzel başladı",Image="1.png",isActive=true,isHome=true},
                new Bootcamp(){Id = 2, Title= "Game Bootcamp",Description="Güzel başladı",Image="2.png",isActive=true,isHome=false},
                new Bootcamp(){Id = 3, Title= "React Bootcamp",Description="Güzel başladı",Image="3.jpg",isActive=true,isHome=true},
            };
        }
        public static List<Bootcamp> Bootcamps{get{return _bootcamps;}}

        public static Bootcamp? GetById(int? id){
            return _bootcamps.FirstOrDefault(c=>c.Id == id);
        }
    }
}