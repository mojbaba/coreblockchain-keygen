using Sharprompt;
using Xcb.Net.Extensions;

Xcb.Net.BIP39.Mnemonic24 mnemonicPhrase;

if (Prompt.Select<bool>("Generate new mnemonic?", new[] { true, false }))
    mnemonicPhrase = Xcb.Net.BIP39.Mnemonic24.GenerateMnemonic();
else
    mnemonicPhrase = new Xcb.Net.BIP39.Mnemonic24(Prompt.Input<string>("Enter 24 mnemonic words"));

mnemonicPhrase = Xcb.Net.BIP39.Mnemonic24.GenerateMnemonic();

var masterExtendedPrivateKey = mnemonicPhrase.ToExtendedPrivateKey();

var hdwallet = new Xcb.Net.HDWallet.PrivateWallet(masterExtendedPrivateKey);

var derivationPath = "m/44'/654'/0'/0/";

System.Console.WriteLine("Mnemonic phrase: ");
System.Console.WriteLine(mnemonicPhrase.Words);

System.Console.WriteLine();

var networkId = Prompt.Input<int>("what is the network id? (testnet = 3 , mainnet = 1)");

var count = Prompt.Input<uint>("how many addresses you want?");
System.Console.WriteLine();

for (int i = 0; i < count; i++)
{
    var mnemonic = derivationPath + $"{i}";

    var privateKey = hdwallet.DerivePrivateWallet(mnemonic).GetExtendedPrivateKey().ToXcbECKey(networkId);

    var address = privateKey.GetAddress();

    System.Console.WriteLine($"the address at {mnemonic} is : {address}");
    System.Console.WriteLine($"the private key is : {privateKey.GetPrivateKey().ToHex()}");

    System.Console.WriteLine();
    System.Console.WriteLine();    
}