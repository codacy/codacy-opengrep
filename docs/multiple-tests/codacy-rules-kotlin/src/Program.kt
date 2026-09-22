class Program {
    fun main() {
        val password = "password" // Issue: Hardcoded password
        val apiKey = "api_key" // Issue: Hardcoded API key
        val apiSecret: String = "api_secret" // Issue: Hardcoded API secret

        println("This is a security risk: $password")
        println("This is a security risk: $apiKey")
        println("This is a security risk: $apiSecret")
    }
}
