using System;

namespace MongoTest2.Infrastructure.Crypto
{
    public class EmptyCryptoStrategy : ICryptoStrategy
    {
        public string Encrypt(string text)
        {
            return text;
        }
    }
}