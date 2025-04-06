import React, { useState, useRef, useEffect } from "react";
import { IonIcon, IonPage, IonMenuButton, IonContent, IonHeader, IonToolbar, IonTitle, IonInput, IonItem, IonLabel, IonButton, IonGrid, IonRow, IonCol, IonAlert, IonButtons } from "@ionic/react";
import ReCAPTCHA from "react-google-recaptcha";
import { useHistory } from "react-router-dom";
import axios from 'axios'; // Import Axios
import "./Login.css"; // Import CSS for styling
import '../theme/customcolors.css';
import { helpSharp, analyticsSharp, homeSharp, peopleSharp } from 'ionicons/icons';

const Login: React.FC = () => {

  useEffect(() => {
    const someuid = localStorage.getItem("uid");
    if (someuid == null || someuid === '901') {
      alert('Welcome to CockyEnterprises.Learn Portal');
      localStorage.setItem("uid", "901");
      localStorage.setItem("email", "visitor@590team1.info");
      localStorage.setItem("fullname", "590 Visitor");
      localStorage.setItem("firstname", "Visitor");
      localStorage.setItem("lastname", "590Team1");
      localStorage.setItem("role", "guest");
    } 
    else if (Number(someuid) <= 900) {
       window.open('https://www.590team1.info/loggedin.html');
    } 
    else {
      history.push("/LoggedIn");
      window.open('https://www.590team1.info/loggedin.html');
    }
  }, [history]);

  // Handles the login process
  const handleLogin = async () => {
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

    try {
      // Fetch user data asynchronously
      const response = await axios.get('http://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/api/Users', { timeout: 5000 });
      const userList = response.data; // Fetch the user list from the API response
      
      // Find a matching user with the entered username and plainpassword
      const user = userList.find(user => 
        user.username === username.trim() && user.plainpassword === password.trim()
      );

      if (user) {
        // Successful login logic
        history.push("/MyCerts");
        alert(`${user.role.charAt(0).toUpperCase() + user.role.slice(1)} Login Successful!`);
        localStorage.setItem("uid", user.id);
        localStorage.setItem("email", user.email);
        localStorage.setItem("fullname", user.fullname);
        localStorage.setItem("firstname", user.firstname);
        localStorage.setItem("lastname", user.lastname);
        localStorage.setItem("username", user.username);
        localStorage.setItem("role", user.role);
      } else {
        // Invalid username or password
        setAlertMessage("Invalid username or password.");
        setShowAlert(true);
      }
    } catch (error) {
      // Handle API errors
      history.push("/LoggedIn");
      alert("Failed to fetch user data. Please try again later.");
      console.error(error);
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
    localStorage.setItem("lastname", "590Team1");
    localStorage.setItem("role", "guest");
  };

  const { name } = useParams<{ name: string; }>();

  return (
    <IonPage>
	
      <IonHeader>
        <IonToolbar color = "dark">
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
	   <IonButton routerLink="/Help"> 
		<IonIcon slot="icon-only" icon={helpSharp}></IonIcon>
	    </IonButton>
          </IonButtons>
          <IonTitle text-right>@Identity.Manager</IonTitle>
        </IonToolbar>
      </IonHeader>

      <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar color = "dark"><IonTitle>@Identity.Manager</IonTitle>
           </IonToolbar>
        </IonHeader>
        <Iframe url="https://www.590team1.info/login.html"
        width="100%"
        height="1000px"
        id=""
        className=""
        display="block"
        position="relative"/>
      </IonContent>
    </IonPage>
  );
};

export default Login;
