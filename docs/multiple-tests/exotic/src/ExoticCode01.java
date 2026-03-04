public class ExoticCode01 {
    public void example() {
        // This is an exotic code snippet with a unique pattern
    }


    public String buildUserQuery(String tableName, String username) {
        // Initialize StringBuilder with a starting capacity or initial string
        StringBuilder query = new StringBuilder("SELECT * FROM ");
        
        // Dynamically append parts of the query
        query.append(tableName);
        query.append(" WHERE status = 'ACTIVE'");
        
        // ❌ org_id should not be hardcoded
        query.append(" AND org_id = 85");
        // query.append(" AND org_id = 85");
        query.append(" AND language = 'FRC'");

        if (username != null && !username.isEmpty()) {
            query.append(" AND username = '");
            query.append(username);
            query.append("'");
        }
        
        query.append(";");

        return query.toString();
    }
}