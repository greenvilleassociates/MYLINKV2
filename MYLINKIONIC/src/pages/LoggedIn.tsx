import { useParams } from 'react-router';
import '../theme/customcolors.css';
import Iframe from 'react-iframe';
import './LoggedIn.css';
import React, { useState, useRef, useEffect } from "react";
import { IonIcon, IonPage, IonMenuButton, IonContent, IonHeader, IonToolbar, IonTitle, IonInput, IonItem, IonLabel, IonButton, IonGrid, IonRow, IonCol, IonAlert, IonButtons } from "@ionic/react";
import ReCAPTCHA from "react-google-recaptcha";
import { useHistory } from "react-router-dom";
import axios from 'axios'; // Import Axios
import "./Login.css"; // Import CSS for styling
import '../theme/customcolors.css';
import { roseSharp, helpSharp, analyticsSharp, homeSharp, peopleSharp } from 'ionicons/icons';

const LoggedIn: React.FC = () => {
  const history = useHistory();
  const fullname = localStorage.getItem("Fullname");
  const status = localStorage.getItem("status");
  const displayText = status === "loggedin" ? fullname : "Not logged in";

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
		<IonIcon slot="icon-only" icon={roseSharp}></IonIcon>
	    </IonButton>
          </IonButtons>
          <IonTitle text-right>@Identity</IonTitle>
        </IonToolbar>
      </IonHeader>

      <IonContent className="ion-padding">
        <IonHeader collapse="condense">
          <IonToolbar color = "danger"><IonTitle>@Identity</IonTitle>
           </IonToolbar>
        </IonHeader>
        <div style={{ 
          backgroundColor: 'yellow', 
          color: 'black', 
          padding: '10px', 
          textAlign: 'center', 
          fontWeight: 'bold' 
        }}>
          {displayText}
        </div>
        <IonButton class="shrinkbutton" expand="block" onClick={() => history.push('/login')}>Login</IonButton>
        <IonButton class="shrinkbutton" expand="block" onClick={() => history.push('/LogOut')}>Logout</IonButton>
        <IonButton class="shrinkbutton" expand="block" onClick={() => window.location.reload()}>Refresh Page</IonButton>
        <IonButton class="shrinkbutton" expand="block" onClick={() => history.push('/ResetPassword')}>Reset Password</IonButton>
        <IonButton class="shrinkbutton" expand="block" onClick={() => history.push('/ForgotPassword')}>Forgot Password</IonButton>
        <IonButton class="shrinkbutton" expand="block" onClick={() => history.push('/Register')}>Register</IonButton>
        <IonButton class="shrinkbutton" expand="block" onClick={() => history.push('/Accesslogs')}>Security Logs</IonButton>
	<IonButton class="shrinkbutton" expand="block" onClick={() => history.push('/LoggedIn3')}>AccessDetail</IonButton>
	<IonButton class="shrinkbutton" expand="block" onClick={() => history.push('/LoginJquery')}>LoginJquery</IonButton>
      </IonContent>
    </IonPage>
  );
};

export default LoggedIn;