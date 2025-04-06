import React, { useState, useRef, useEffect } from "react";
import { IonIcon, IonPage, IonMenuButton, IonContent, IonHeader, IonToolbar, IonTitle, IonInput, IonItem, IonLabel, IonButton, IonGrid, IonRow, IonCol, IonAlert, IonButtons, IonBackButton } from "@ionic/react";
import ReCAPTCHA from "react-google-recaptcha";
import { useHistory } from "react-router-dom";
import "./Login.css"; // Import CSS for styling
import '../theme/customcolors.css';
import { analyticsSharp,homeSharp, heart, peopleSharp, flagSharp } from 'ionicons/icons';

const Login: React.FC = () => {
  const [username, setUsername] = useState(""); // Stores username input
  const [password, setPassword] = useState(""); // Stores password input
  const [showAlert, setShowAlert] = useState(false); // Controls the login failure alert
  const [alertMessage, setAlertMessage] = useState(""); // Stores alert message text
  const [captchaToken, setCaptchaToken] = useState(""); // Stores CAPTCHA token
  const history = useHistory(); // Used for page redirection
  const recaptchaRef = useRef<ReCAPTCHA>(null); // Create a ref for reCAPTCHA

 useEffect(() => {
    var someuid = localStorage.getItem("uid");
    if (someuid == null || someuid == '901')
    {
    alert('Hello Earthlings Welcome to CockyEnterprises.Learn Portal');
    localStorage.setItem("uid", "901");
    localStorage.setItem("email", "visitor@590team1.info");
    localStorage.setItem("fullname", "590 Visitor");
    localStorage.setItem("firstname", "Visitor");
    localStorage.setItem("firstname", "590Team1");
    localStorage.setItem("role", "guest");
    }
    else if (Number(someuid) >= 1)
    {
    window.open('https://www.590team1.info/loggedin.html');
    }
    else
    {
    //setPage(Profile);
    history.push("/Profile");
    window.open('https://www.590team1.info/loggedin.html');
    //window.open('https://profile.html', '_self');
    }
  }, []);


  // Handles the login process (without API)
  const handleLogin = () => {
    // Check if username and password are filled
    if (!username.trim() || !password.trim()) {
      setAlertMessage("Username and password cannot be empty.");
      setShowAlert(true);
      return;
    }

    if (!captchaToken) {
      setAlertMessage("Please complete the CAPTCHA.");
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
    } else {
      setAlertMessage("Invalid username or password.");
      setShowAlert(true);
    }
  };

  // Clears input fields and reCAPTCHA token
  const handleClear = () => {
    setUsername("");
    setPassword("");
    setCaptchaToken("");
    recaptchaRef.current?.reset(); // Reset CAPTCHA
    localStorage.setItem("uid", "901");
    localStorage.setItem("email", "visitor@590team1.info");
    localStorage.setItem("fullname", "590 Visitor");
    localStorage.setItem("firstname", "Visitor");
    localStorage.setItem("firstname", "590Team1");
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
                  <IonLabel position="floating">Username</IonLabel>
                  <IonInput type="email" value={username} onIonChange={(e) => setUsername(e.detail.value!)} />
                </IonItem>

                {/* Password Input */}
                <IonItem>
                  <IonLabel position="floating">Password</IonLabel>
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

        {/* UofSC Cocky Image with Click Event to Redirect to Home */}
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
