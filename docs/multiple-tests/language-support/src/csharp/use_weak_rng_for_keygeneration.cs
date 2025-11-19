using System;
using System.Security.Cryptography;
using System.IO;
					
public class Program
{	
	public void GenerateBadKey() {
		var rng = new System.Random();
		byte[] key = new byte[16];
		rng.NextBytes(key);
		SymmetricAlgorithm cipher = Aes.Create();
		// ruleid: use_weak_rng_for_keygeneration
		cipher.Key = key;
	}
	
	public void GenerateBadKeyGcm() {
		var rng = new System.Random();
		byte[] key = new byte[16];
		rng.NextBytes(key);
		// ruleid: use_weak_rng_for_keygeneration
		var cipher = new AesGcm(key);
	}
	
	public void GenerateGoodKey() {
		var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
		byte[] key = new byte[16];
		rng.GetBytes(key);
		var cipher = Aes.Create();
		// ok: use_weak_rng_for_keygeneration
		cipher.Key = key;
	}

	public void GenerateGoodKeyGcm() {
		var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
		byte[] key = new byte[16];
		rng.GetBytes(key);
		// ok: use_weak_rng_for_keygeneration
		var cipher = new AesGcm(key);
	}

	public void GenerateBadKeyCcm() {
		var rng = new System.Random();
		byte[] key = new byte[16];
		rng.NextBytes(key);
		// ruleid: use_weak_rng_for_keygeneration
		var cipher = new AesCcm(key);
	}

	public void GenerateGoodKeyCcm() {
		var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
		byte[] key = new byte[16];
		rng.GetBytes(key);
		// ok: use_weak_rng_for_keygeneration
		var cipher = new AesCcm(key);
	}

	public void GenerateBadKeyChaCha20() {
		var rng = new System.Random();
		byte[] key = new byte[16];
		rng.NextBytes(key);
		// ruleid: use_weak_rng_for_keygeneration
		var cipher = new ChaCha20Poly1305(key);
	}

	public void GenerateGoodKeyChaCha20() {
		var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
		byte[] key = new byte[16];
		rng.GetBytes(key);
		// ok: use_weak_rng_for_keygeneration
		var cipher = new ChaCha20Poly1305(key);
	}

	// Unsafe path combine examples - using Path.Combine with unsanitized user input
	public void UnsafePathCombineBad(string userInput) {
		string basePath = "/var/www/files/";
		// ruleid: unsafe-path-combine
		string filePath = Path.Combine(basePath, userInput);
		File.ReadAllText(filePath);
	}

	public void UnsafePathCombineBad2(string fileName) {
		string baseDirectory = @"C:\app\data\";
		// ruleid: unsafe-path-combine
		string fullPath = Path.Combine(baseDirectory, fileName);
		File.WriteAllText(fullPath, "content");
	}

	public void UnsafePathCombineBad3(string userPath) {
		string baseDirectory = @"C:\uploads\";
		// ruleid: unsafe-path-combine
		string combinedPath = Path.Combine(baseDirectory, userPath);
		File.ReadAllBytes(combinedPath);
	}

	public void SafePathCombineGood(string fileName) {
		string baseDirectory = @"C:\app\data\";
		// ok: unsafe-path-combine
		string safePath = Path.Combine(baseDirectory, Path.GetFileName(fileName));
		File.ReadAllText(safePath);
	}

	public void SafePathCombineGood2(string userInput) {
		string basePath = "/var/www/files/";
		// ok: unsafe-path-combine
		string sanitizedFileName = Path.GetFileName(userInput);
		string safePath = Path.Combine(basePath, sanitizedFileName);
		File.WriteAllText(safePath, "content");
	}
}