using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Common
{
    public struct Password
    {
        private readonly string passwordString;
        public Password(string passwordString)
        {
            this.passwordString = passwordString;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                Key = hmac.Key;
                Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordString));
            }
        }

        public Password(string passwordString, byte[] key)
        {
            if (string.IsNullOrEmpty(passwordString))
                throw new ArgumentNullException("password");

            if (key == null || key.Length != 128)
                throw new ArgumentException("Invalid length of password salt");

            this.passwordString = passwordString;
            Key = key;

            using (var hmac = new System.Security.Cryptography.HMACSHA512(key))
            {
                Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordString));
            }
        }

        public byte[] Hash { get; }
        public byte[] Key { get; }

        public override string ToString()
        {
            return passwordString;
        }
    }
}
