import React from 'react';

// ============================================
// 1. JSX ELEMENT CONTENT - Should BE flagged
// ============================================

function WelcomeComponent() {
  return (
    <div>
      <h1>Welcome to our application</h1>
      <p>Please enter your information.</p>
      <button>Submit Form</button>
      <span>Loading data from server...</span>
    </div>
  );
}

// ============================================
// 2. JSX ELEMENT CONTENT - Should NOT be flagged
// ============================================

function CorrectComponent({ userName, t }) {
  return (
    <div>
      <div>{userName}</div>
      <div>{t('welcome.message')}</div>
      <span>{count}</span>
      <p>ID</p> {/* Very short technical text */}
    </div>
  );
}

// ============================================
// 3. JSX USER PROPS - Should BE flagged
// ============================================

function FormComponent() {
  return (
    <div>
      <input placeholder="Enter your name" />
      <input title="User email address" />
      <img alt="Company logo" src="logo.png" />
      <button aria-label="Close dialog">X</button>
      <TextField label="Email Address" />
      <Tooltip title="Click to save your changes">
        <button>Save</button>
      </Tooltip>
    </div>
  );
}

// ============================================
// 4. JSX USER PROPS - Should NOT be flagged
// ============================================

function CorrectFormComponent({ t }) {
  return (
    <div>
      <input placeholder={t('form.name.placeholder')} />
      <img alt={t('logo.alt')} src="logo.png" />
      <button aria-label={t('close')}>X</button>
      <div title="ID" /> {/* Very short */}
    </div>
  );
}

// ============================================
// 5. ALERT/CONFIRM/PROMPT - Should BE flagged
// ============================================

function AlertComponent() {
  function handleDelete() {
    alert("Error: File not found");
    
    if (confirm("Are you sure you want to delete?")) {
      // delete logic
    }
    
    const name = prompt("Please enter your name");
  }
  
  return <button onClick={handleDelete}>Delete</button>;
}

// ============================================
// 6. ALERT/CONFIRM/PROMPT - Should NOT be flagged
// ============================================

function CorrectAlertComponent({ t }) {
  function handleDelete() {
    alert(t('error.fileNotFound'));
    
    if (confirm(t('confirm.delete'))) {
      // delete logic
    }
    
    const name = prompt(t('prompt.enterName'));
  }
  
  return <button onClick={handleDelete}>Delete</button>;
}

// ============================================
// 7. CONDITIONAL TEXT - Should BE flagged
// ============================================

function ConditionalComponent({ isOnline, count }) {
  return (
    <div>
      <span>{isOnline ? "User is online" : "User is offline"}</span>
      <p>{count > 0 ? "Items available" : "Out of stock"}</p>
      <div>{hasError ? "An error occurred" : "Success"}</div>
    </div>
  );
}

// ============================================
// 8. CONDITIONAL TEXT - Should NOT be flagged (technical values)
// ============================================

function ConditionalTechnicalComponent({ variant, type, position }) {
  return (
    <div>
      <Button variant={isOutlined ? "outlined" : "contained"} />
      <div style={{ position: isFixed ? "fixed" : "relative" }} />
      <Input type={isNumber ? "number" : "string"} />
      <div className={isHidden ? "hidden" : "visible"} />
      <span>{userId ? userId : "default_id"}</span>
      <div sx={{ display: isOpen ? "block" : "none" }} />
    </div>
  );
}

// ============================================
// 9. CONSOLE.ERROR - Should BE flagged
// ============================================

function DataLoadingComponent() {
  async function loadData() {
    try {
      const data = await fetch('/api/users');
    } catch (error) {
      console.error("Failed to load user data");
      console.error("Authentication error occurred");
      console.error("Network connection timeout");
    }
  }
  
  return <button onClick={loadData}>Load Data</button>;
}

// ============================================
// 10. CONSOLE.ERROR - Should NOT be flagged
// ============================================

function CorrectDataLoadingComponent({ t }) {
  async function loadData() {
    try {
      const data = await fetch('/api/users');
    } catch (error) {
      console.error(t('error.dataLoad'));
      console.error(error); // Variable
      console.error("ERR"); // Very short
    }
  }
  
  return <button onClick={loadData}>Load Data</button>;
}

// ============================================
// 11. ERROR CONSTRUCTOR - Should BE flagged
// ============================================

function ValidationComponent() {
  function validateUser(user) {
    if (!user.email) {
      throw new Error("Invalid user credentials");
    }
    
    if (!user.password) {
      throw new Error("Password is required");
    }
    
    try {
      // some logic
    } catch (e) {
      throw new Error("Network request failed");
    }
  }
  
  return <button onClick={validateUser}>Validate</button>;
}

// ============================================
// 12. ERROR CONSTRUCTOR - Should NOT be flagged
// ============================================

function CorrectValidationComponent({ t }) {
  function validateUser(user) {
    if (!user.email) {
      throw new Error(t('error.invalidCredentials'));
    }
    
    if (!user.password) {
      throw new Error(t('error.passwordRequired'));
    }
    
    // Very short technical error
    throw new Error("ERR01");
  }
  
  return <button onClick={validateUser}>Validate</button>;
}

// ============================================
// 13. NUMBER FORMATTING - Should BE flagged
// ============================================

function PriceComponent({ price, quantity }) {
  return (
    <div>
      <p>Price: ${price.toFixed(2)}</p>
      <p>Quantity: {quantity.toLocaleString()}</p>
      <p>Total: ${(price * quantity).toFixed(2)}</p>
      <span>{Number(price).toLocaleString()}</span>
    </div>
  );
}

// ============================================
// 14. NUMBER FORMATTING - Should NOT be flagged
// ============================================

function CorrectPriceComponent({ price, t }) {
  const formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD'
  });
  
  return (
    <div>
      <p>{formatter.format(price)}</p>
      <p>{t('price', { value: price })}</p>
      <p>{price.toLocaleString('en-US', { style: 'currency', currency: 'USD' })}</p>
    </div>
  );
}

// ============================================
// 15. MIXED EXAMPLES - Should BE flagged
// ============================================

function ComplexComponent({ user, count }) {
  const handleSave = () => {
    if (count === 0) {
      alert("No items to save");
      return;
    }
    
    try {
      // save logic
      console.log("Saved successfully");
    } catch (error) {
      console.error("Failed to save data");
      throw new Error("Save operation failed");
    }
  };
  
  return (
    <div>
      <h2>Welcome back, {user.name}!</h2>
      <p>{count > 0 ? "You have items" : "Cart is empty"}</p>
      <input placeholder="Enter comment" />
      <button onClick={handleSave}>Save Changes</button>
      <span>Total: ${user.balance.toFixed(2)}</span>
    </div>
  );
}

export default ComplexComponent;
