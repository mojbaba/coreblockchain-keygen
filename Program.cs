﻿using Xcb.Net.Extensions;
using Xcb.Net.HDWallet;

var masterExtendedPrivateKey = ExtendedPrivateKey.GenerateRandomMaster();

var keyBytes = (byte[])masterExtendedPrivateKey;

System.Console.WriteLine("Master Extended Private Key: ");

System.Console.WriteLine(keyBytes.ToHex());


var masterExtendedPublicKey = masterExtendedPrivateKey.ToExtendedPublicKey();

System.Console.WriteLine("Master Extended Public Key: ");

System.Console.WriteLine(((byte[])masterExtendedPublicKey).ToHex());

var privateKey = Xcb.Net.Signer.XcbECKey.GenerateKey(1).GetPrivateKey();

System.Console.WriteLine("Randome Private Key: ");

System.Console.WriteLine(privateKey.ToHex());