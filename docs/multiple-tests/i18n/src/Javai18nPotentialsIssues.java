package examples;

import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.time.format.DateTimeFormatter;
import java.util.ResourceBundle;

/**
 * Test file for Java i18n Semgrep rules
 * Each section tests a specific rule with both positive (should flag) 
 * and negative (should NOT flag) test cases
 */
public class JavaI18nTest {

    private ResourceBundle bundle = ResourceBundle.getBundle("messages");

    // ============================================
    // 1. HARDCODED RETURN STRING - Should BE flagged
    // ============================================

    public String getUserStatus() {
        return "Invalid username or password";
    }

    public String getEmailError() {
        return "Please enter a valid email";
    }

    public String getSuccessMessage() {
        return "Your account has been created successfully.";
    }

    public String getWelcomeText() {
        return "Welcome to our platform!";
    }

    // ============================================
    // 2. HARDCODED RETURN STRING - Should NOT be flagged
    // ============================================

    public String getI18nMessage() {
        return bundle.getString("error.login.invalid");
    }

    public String getPropertyKey() {
        return "user.email.validation";
    }

    public String getSqlQuery() {
        return "SELECT * FROM users WHERE email = ?";
    }

    public String getToString() {
        return "User[id=" + id + ", name=" + name + "]";
    }

    public String getTechnicalId() {
        return "user_session_id";
    }

    public String getEmptyString() {
        return "";
    }

    // ============================================
    // 3. STRING CONCATENATION - Should BE flagged
    // ============================================

    public String getUserGreeting(String userName) {
        return "Hello, " + userName;
    }

    public String getItemCount(int count) {
        return count + " items selected";
    }

    public String getWelcomeMessage(String name) {
        return "Welcome back, " + name + "!";
    }

    public String getErrorWithDetails(String detail) {
        return "Error occurred: " + detail;
    }

    // ============================================
    // 4. STRING CONCATENATION - Should NOT be flagged
    // ============================================

    public String getI18nConcatenation(String userName) {
        return bundle.getString("greeting.hello") + userName;
    }

    public String getSqlWithParam(String table) {
        return "SELECT * FROM " + table + " WHERE active = 1";
    }

    public String getKeyPath(String module) {
        return "error." + module + ".invalid";
    }

    public String getToStringConcat() {
        return "Order[id=" + orderId + ", total=" + total + "]";
    }

    // ============================================
    // 5. STRINGBUILDER APPEND - Should BE flagged
    // ============================================

    public String buildMessage() {
        StringBuilder sb = new StringBuilder();
        sb.append("The process has completed successfully.");
        return sb.toString();
    }

    public String buildErrorMessage() {
        StringBuilder sb = new StringBuilder();
        sb.append("Error: Invalid input provided.");
        sb.append("Please check your data and try again.");
        return sb.toString();
    }

    public String buildNotification() {
        StringBuilder sb = new StringBuilder();
        sb.append("Your order has been shipped.");
        return sb.toString();
    }

    // ============================================
    // 6. STRINGBUILDER APPEND - Should NOT be flagged
    // ============================================

    public String buildSqlQuery() {
        StringBuilder sb = new StringBuilder();
        sb.append("SELECT u.id, u.name ");
        sb.append("FROM users u ");
        sb.append("WHERE u.active = ? ");
        sb.append("ORDER BY u.created_date DESC");
        return sb.toString();
    }

    public String buildHql() {
        StringBuilder sb = new StringBuilder();
        sb.append("FROM Order o ");
        sb.append("JOIN o.customer c ");
        sb.append("WHERE o.status = :status");
        return sb.toString();
    }

    public String buildTechnicalString() {
        StringBuilder sb = new StringBuilder();
        sb.append("user_");
        sb.append(userId);
        sb.append("_session");
        return sb.toString();
    }

    // ============================================
    // 7. DATE FORMATS - Should BE flagged
    // ============================================

    public SimpleDateFormat getDateFormatter1() {
        return new SimpleDateFormat("MM/dd/yyyy");
    }

    public SimpleDateFormat getDateFormatter2() {
        return new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
    }

    public DateTimeFormatter getDateFormatter3() {
        return DateTimeFormatter.ofPattern("yyyy-MM-dd");
    }

    public DateTimeFormatter getDateFormatter4() {
        return DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm");
    }

    // ============================================
    // 8. DATE FORMATS - Should NOT be flagged
    // ============================================

    public DateTimeFormatter getLocalizedDateFormatter() {
        return DateTimeFormatter.ofLocalizedDate(FormatStyle.MEDIUM);
    }

    public DateTimeFormatter getLocalizedDateTimeFormatter() {
        return DateTimeFormatter.ofLocalizedDateTime(FormatStyle.SHORT, FormatStyle.SHORT);
    }

    // Comment with date format: "MM/dd/yyyy" - should not be flagged

    // ============================================
    // 9. NUMBER FORMATS - Should BE flagged
    // ============================================

    public DecimalFormat getNumberFormatter1() {
        return new DecimalFormat("#,##0.00");
    }

    public DecimalFormat getNumberFormatter2() {
        return new DecimalFormat("0.00");
    }

    public String formatPrice(double price) {
        return String.format("%.2f", price);
    }

    public String formatPercentage(double value) {
        return String.format("%.1f%%", value);
    }

    // ============================================
    // 10. NUMBER FORMATS - Should NOT be flagged
    // ============================================

    public String getFormattedNumber(double value) {
        NumberFormat formatter = NumberFormat.getInstance(locale);
        return formatter.format(value);
    }

    // Comment with format: "#,##0.00" - should not be flagged

    // ============================================
    // 11. VALIDATION MESSAGE - Should BE flagged
    // ============================================

    public String validateEmail(String email) {
        if (email == null || !email.contains("@")) {
            return "Please enter a valid email address";
        }
        return null;
    }

    public String validatePassword(String password) {
        if (password.length() < 8) {
            return "Password must be at least 8 characters long";
        }
        return null;
    }

    public String validateAge(int age) {
        if (age < 18) {
            return "You must be at least 18 years old";
        }
        return null;
    }

    // ============================================
    // 12. VALIDATION MESSAGE - Should NOT be flagged
    // ============================================

    public String validateEmailCorrect(String email) {
        if (email == null || !email.contains("@")) {
            return bundle.getString("validation.email.invalid");
        }
        return null;
    }

    public String validateWithKey(String password) {
        if (password.length() < 8) {
            return "error.password.tooShort";
        }
        return null;
    }

    public String validateWithSql() {
        return "SELECT COUNT(*) FROM users WHERE email = ?";
    }

    // ============================================
    // 13. ERROR MESSAGE - Should BE flagged
    // ============================================

    public String handleError1() {
        return "Error: Unable to process request";
    }

    public String handleError2() {
        return "Invalid username format";
    }

    public String handleError3() {
        return "Please try again later";
    }

    public String handleWarning() {
        return "Warning: This action cannot be undone";
    }

    // ============================================
    // 14. ERROR MESSAGE - Should NOT be flagged
    // ============================================

    public String handleErrorCorrect() {
        return bundle.getString("error.processing.failed");
    }

    public String getErrorKey() {
        return "error.authentication.invalid";
    }

    public String getErrorCode() {
        return "ERR_401";
    }

    // ============================================
    // 15. EXCEPTION MESSAGE - Should BE flagged
    // ============================================

    public void throwException1() {
        throw new IllegalArgumentException("Invalid input provided");
    }

    public void throwException2() {
        throw new RuntimeException("Operation failed");
    }

    public void throwException3() {
        throw new IllegalStateException("User is not authenticated");
    }

    public void throwException4() {
        if (data == null) {
            throw new NullPointerException("Data cannot be null");
        }
    }

    // ============================================
    // 16. EXCEPTION MESSAGE - Should NOT be flagged
    // ============================================

    public void throwExceptionCorrect1() {
        throw new IllegalArgumentException(bundle.getString("error.invalid.input"));
    }

    public void throwExceptionCorrect2() {
        throw new RuntimeException("error.operation.failed");
    }

    public void throwExceptionCorrect3(Exception e) {
        throw new RuntimeException(e); // Exception as cause, no message
    }

    public void throwExceptionCorrect4() {
        throw new IllegalArgumentException("ERR_500");
    }

    // ============================================
    // 17. GREETING MESSAGE - Should BE flagged
    // ============================================

    public String getGreeting1() {
        return "Welcome to our application";
    }

    public String getGreeting2() {
        return "Dear Customer";
    }

    public String getGreeting3() {
        return "Hello, thank you for visiting";
    }

    public String getGreeting4() {
        return "Hi there!";
    }

    public String getGreeting5() {
        return "Greetings from our team";
    }

    public String getGreeting6() {
        return "Congratulations on your purchase";
    }

    // ============================================
    // 18. GREETING MESSAGE - Should NOT be flagged
    // ============================================

    public String getGreetingCorrect() {
        return bundle.getString("greeting.welcome");
    }

    // Comment: "Welcome to the system" - should not be flagged

    public void logTest() {
        // Test data: "Dear Test User"
        System.out.println("Running test");
    }

    public void throwHibernateException() {
        // Should NOT flag "Hi" in "HibernateException"
        throw new HibernateException("Database connection error");
    }

    // ============================================
    // 19. MEASUREMENT UNITS - Should BE flagged
    // ============================================

    public String getWeight(double weight) {
        return weight + " lbs";
    }

    public String getDistance(double distance) {
        return distance + " miles";
    }

    public String getHeight(double height) {
        return height + " inches";
    }

    public String getVolume(double volume) {
        return volume + " gallons";
    }

    public String getMetricWeight(double weight) {
        return weight + " kg";
    }

    public String getMetricDistance(double distance) {
        return distance + " km";
    }

    public String getMetricHeight(double height) {
        return height + " cm";
    }

    public String getMetricVolume(double volume) {
        return volume + " liters";
    }

    // ============================================
    // 20. MEASUREMENT UNITS - Should NOT be flagged
    // ============================================

    public String getWeightCorrect(double weight, String unit) {
        return MessageFormat.format(
            bundle.getString("measurement.weight"), 
            weight, 
            unit
        );
    }

    // Comment: "Weight: 150 lbs" - should not be flagged

    // ============================================
    // 21. PLURALIZATION - Should BE flagged
    // ============================================

    public String getItemCount1(int count) {
        if (count == 1) {
            return "1 item";
        } else {
            return count + " items";
        }
    }

    public String getFileCount(int count) {
        if (count == 1) {
            return "1 file selected";
        } else {
            return count + " files selected";
        }
    }

    public String getUserCount(int count) {
        if (count == 1) {
            return "1 user online";
        } else {
            return count + " users online";
        }
    }

    // ============================================
    // 22. PLURALIZATION - Should NOT be flagged
    // ============================================

    public String getItemCountCorrect(int count) {
        MessageFormat mf = new MessageFormat(bundle.getString("items.count"));
        return mf.format(new Object[]{count});
    }

    public String getFileCountCorrect(int count) {
        return MessageFormat.format(
            bundle.getString("files.selected"), 
            count
        );
    }

    public int getTechnicalCount(int count) {
        // Technical counting, not display
        if (count == 1) {
            return 1;
        } else {
            return count;
        }
    }

    // ============================================
    // 23. MIXED EXAMPLES - Should BE flagged
    // ============================================

    public String processOrder(String customerName, int itemCount, double total) {
        StringBuilder message = new StringBuilder();
        
        // Multiple issues in one method
        message.append("Hello, " + customerName + "!");  // Concatenation
        
        if (itemCount == 1) {
            message.append("You have 1 item in your cart.");  // Pluralization
        } else {
            message.append("You have " + itemCount + " items in your cart.");  // Pluralization + Concatenation
        }
        
        message.append("Total: $" + String.format("%.2f", total));  // Number format
        
        if (total > 100) {
            message.append("Congratulations! You qualify for free shipping.");  // Greeting + hardcoded
        }
        
        return message.toString();
    }

    public String validateAndFormat(String email, double price, int quantity) {
        // Validation message
        if (email == null || !email.contains("@")) {
            return "Error: Please provide a valid email address";
        }
        
        // Number formatting
        DecimalFormat df = new DecimalFormat("#,##0.00");
        String formattedPrice = df.format(price);
        
        // String concatenation with measurement
        return "Order total: " + formattedPrice + " for " + quantity + " kg";
    }

    public void validateUserInput(String username, int age) {
        // Exception messages
        if (username == null || username.isEmpty()) {
            throw new IllegalArgumentException("Username cannot be empty");
        }
        
        if (age < 18) {
            throw new IllegalStateException("User must be at least 18 years old");
        }
        
        // Date formatting
        SimpleDateFormat sdf = new SimpleDateFormat("MM/dd/yyyy");
        String dateStr = sdf.format(new Date());
        
        // Return with greeting
        System.out.println("Welcome " + username + ", registered on " + dateStr);
    }
}
