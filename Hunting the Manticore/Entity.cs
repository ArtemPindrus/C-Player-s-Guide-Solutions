namespace HuntingTheManticore {
    public class Entity {
        public int MaxHealth { get; private set; }
        public int Health { get; private set; }

        public bool IsAlive => Health != 0;

        public Entity(int maxHealth) {
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        public void Damage(int damage) {
            Health -= damage;
            if (Health < 0) Health = 0;
        }
    }

    public class Manticore : Entity {
        public int DistanceFromTheCity { get; private set; }

        public Manticore(int initialHealth, int distanceFromTheCity) : base(initialHealth) {
            DistanceFromTheCity = distanceFromTheCity;
        }
    }
}