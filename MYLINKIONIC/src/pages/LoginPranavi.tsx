import React, { useState, useEffect, useRef } from "react";
import { IonIcon, IonPage, IonMenuButton, IonContent, IonHeader, IonToolbar, IonTitle, IonInput, IonItem, IonLabel, IonButton, IonGrid, IonRow, IonCol, IonAlert, IonButtons } from "@ionic/react";
import axios from "axios";
import ReCAPTCHA from "react-google-recaptcha";
import { useHistory } from "react-router-dom"; 
import "./Login.css"; // Import CSS for styling
import { analyticsSharp, homeSharp, peopleSharp } from 'ionicons/icons';

const API_URL = "https://www.590team1.info/userlist.json"; // Replace with actual backend API endpoint

const Login: React.FC = () => {
  const [username, setUsername] = useState(""); // Stores username input
  const [password, setPassword] = useState(""); // Stores password input
  const [showAlert, setShowAlert] = useState(false); // Controls the login failure alert
  const [alertMessage, setAlertMessage] = useState(""); // Stores alert message text
  const [captchaToken, setCaptchaToken] = useState(""); // Stores CAPTCHA token
  const [pll, setPll] = useState(""); // Stores PLL session token
  const history = useHistory(); // Used for page redirection
  const recaptchaRef = useRef<ReCAPTCHA>(null); // Create a ref for reCAPTCHA

 useEffect(() => {
    const someuid = localStorage.getItem("uid");
    if (someuid == null || someuid === '901') {
      alert('Hello Earthlings Welcome to CockyEnterprises.Learn Portal');
      localStorage.setItem("uid", "901");
      localStorage.setItem("email", "visitor@590team1.info");
      localStorage.setItem("fullname", "590 Visitor");
      localStorage.setItem("firstname", "Visitor");
      localStorage.setItem("lastname", "590Team1");
      localStorage.setItem("role", "guest");
    } else if (Number(someuid) >= 1) {
      window.open('https://www.590team1.info/loggedin.html');
    } else {
      history.push("/Profile");
      window.open('https://www.590team1.info/loggedin.html');
    }
     const initialPLL = localStorage.getItem("PLL") || "";
    setPll(initialPLL);

    if (initialPLL) {
      checkSession(initialPLL);
    } 
 }, [history]);

 /* // ✅ On page load, check if there's a stored PLL session
  useEffect(() => {

  }, []);*/

  // ✅ Checks if the stored session is still valid
  const checkSession = async (storedPLL: string) => {
    try {
      const response = await axios.get("/api/check-session", { params: { pll: storedPLL } });

      if (response.data.valid) {
        history.push(response.data.role === "admin" ? "/admin-home" : "/employee-home");
      } else {
        localStorage.removeItem("PLL");
        setPll("");
        history.push("/login");
      }
    } catch {
      localStorage.removeItem("PLL");
      setPll("");
      history.push("/login");
    }
  };


  // ✅ Handles the login process
  const handleLogin = async () => {
    // Check if username and password are filled
    if (!username.trim() || !password.trim()) {
      setAlertMessage("Username and password cannot be empty.");
      setShowAlert(true);
      return;
    }

    // Check if CAPTCHA is completed
    if (!captchaToken) {
      setAlertMessage("Please complete the CAPTCHA.");
      setShowAlert(true);
      return;
    }

    try {
      const response = await axios.post(API_URL, { username, password, captcha: captchaToken });
      const { success, message, hashbit, pllValue, role } = response.data;

      // If account is not ready for login
      if (!hashbit) {
        setAlertMessage("Your account is not ready for login. Please contact support.");
        setShowAlert(true);
        return;
      }
  // Simulated login credentials
    const adminUser = "admin";
    const adminPass = "admin123";
    const employeeUser = "employee";
    const employeePass = "employee123";
    const employeeuid = "9";
    const adminuid = "2";

      // Successful login process
        if (username === adminUser && password === adminPass) {
      history.push("/LoggedIn");
      alert("Admin Login Successful!");
      localStorage.setItem("uid", adminuid);
      localStorage.setItem("email", "billgates@590team1.info");
      localStorage.setItem("fullname", "Bill Gates");
      localStorage.setItem("firstname", "William");
      localStorage.setItem("lastname", "Gates");
      localStorage.setItem("role", "admin");	    
    } else if (username === employeeUser && password === employeePass) {
      history.push("/LoggedIn");
      alert("Employee Login Successful!");
      localStorage.setItem("uid", employeeuid);
      localStorage.setItem("email", "ronak@590team1.info");
      localStorage.setItem("fullname", "Ronak LongLastName");
      localStorage.setItem("firstname", "Ronak");
      localStorage.setItem("lastname", "LongLastName");
      localStorage.setItem("role", "registered");
    }
    else if (user) {
          history.push("/LoggedIn");
          alert(`${user.role.charAt(0).toUpperCase() + user.role.slice(1)} Login Successful!`);
          localStorage.setItem("uid", user.id);
          localStorage.setItem("email", user.email);
          localStorage.setItem("fullname", user.fullname);
          localStorage.setItem("firstname", user.firstname);
          localStorage.setItem("lastname", user.lastname);
          localStorage.setItem("username", user.username);
          localStorage.setItem("role", user.role);
        } 
    else 
        {
        setAlertMessage(message || "Invalid username or password.");
        setShowAlert(true);
      }
    } 
      catch {
      setAlertMessage("Login failed. Please try again.");
      setShowAlert(true);
    }
  };

  // ✅ Clears input fields and reCAPTCHA token
  const handleClear = () => {
    setUsername("");
    setPassword("");
    setCaptchaToken("");
    recaptchaRef.current?.reset(); // ✅ Reset CAPTCHA
    localStorage.setItem("uid", "901");
    localStorage.setItem("email", "visitor@590team1.info");
    localStorage.setItem("fullname", "590 Visitor");
    localStorage.setItem("firstname", "Visitor");
    localStorage.setItem("lastname", "590Team1");
    localStorage.setItem("role", "guest");
  };

 return (
    <IonPage className="login-page">
      <IonHeader>
        <IonToolbar color="danger">
          <IonButtons slot="start">
            <IonMenuButton />
          </IonButtons>
          <IonButtons slot="end">
            <IonButton routerLink="/Home">
              <IonIcon slot="icon-only" icon={homeSharp}></IonIcon>
            </IonButton>
            <IonButton routerLink="/LoggedIn">
              <IonIcon slot="icon-only" icon={analyticsSharp}></IonIcon>
            </IonButton>
            <IonButton routerLink="/Profile">
              <IonIcon slot="icon-only" icon={peopleSharp}></IonIcon>
            </IonButton>
          </IonButtons>
          <IonTitle text-right>Cocky Identity Manager - Login</IonTitle>
        </IonToolbar>
      </IonHeader>

      <IonContent className="ion-padding">
        <IonGrid>
          <IonRow className="ion-justify-content-center">
            <IonCol size="12" size-md="6">
              <div className="login-container">
                <h2 className="ion-text-center">Welcome Back!</h2>
                {/* Username Input */}
                <IonItem>
                  <IonLabel position="stacked">Username</IonLabel>
                  <IonInput type="email" value={username} onIonChange={(e) => setUsername(e.detail.value!)} />
                </IonItem>

                {/* Password Input */}
                <IonItem>
                  <IonLabel position="stacked">Password</IonLabel>
                  <IonInput type="password" value={password} onIonChange={(e) => setPassword(e.detail.value!)} />
                </IonItem>

                {/* Google reCAPTCHA */}
                <ReCAPTCHA
                  sitekey="6LeIxAcTAAAAAJcZVRqyHh71UMIEGNQ_MXjiZKhI"
                  onChange={(token) => setCaptchaToken(token!)}
                  ref={recaptchaRef} // Assign ref
                />
              </div>

              {/* Login and Clear Buttons */}
              <IonButton className="ion-margin-top" onClick={handleLogin}>Login</IonButton>
              <IonButton className="ion-margin-top" color="medium" onClick={handleClear}>Cancel</IonButton>

              {/* Forgot Password Link */}
              <IonButton expand="full" fill="clear" routerLink="/ForgotPassword">
                Forgot Password?
              </IonButton>
              <IonButton expand="full" fill="clear" routerLink="/Register">
                Register?
              </IonButton>

              {/* Login Alert Message */}
              <IonAlert
                isOpen={showAlert}
                onDidDismiss={() => setShowAlert(false)}
                header="Login Failed"
                message={alertMessage}
                buttons={["OK"]}
              />
            </IonCol>
          </IonRow>
        </IonGrid>

        {/* UofSC Cocky Image */}
        <img
          src="https://m.media-amazon.com/images/I/61Q45cPqUzL._AC_UF894,1000_QL80_.jpg"
          alt="Cocky UofSC"
          className="cocky-image"
        />
      </IonContent>
    </IonPage>
  );
};

export default Login;
