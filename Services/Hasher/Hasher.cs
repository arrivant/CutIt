using HashidsNet;

namespace CutIt.Services.Hasher
{
    public class Hasher : IHasher
    {
        private readonly Hashids _hashid;
        private const int  hashLength = 7;
        public Hasher()
        {
            _hashid = new Hashids("To see things in the seed, this is a genius", hashLength);
        }

        public string GetHash(string value)
        {
            return _hashid.Encode(value.GetHashCode());
        }
    }
}