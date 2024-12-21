using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using UnityEngine;
using UnityEngine.Networking;

public abstract class LeaderboardInterface
{
    protected string host = "http://127.0.0.1:5000"; // localhost
    protected string secret = "";

    protected static string sha256(string randomString)
    {
        var crypt = new System.Security.Cryptography.SHA256Managed();
        var hash = new System.Text.StringBuilder();
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
        foreach (byte theByte in crypto)
        {
            hash.Append(theByte.ToString("x2"));
        }
        return hash.ToString();
    }

    public abstract IEnumerator Get(Func<UnityWebRequest, bool> callback);
    public abstract IEnumerator Post();

}
