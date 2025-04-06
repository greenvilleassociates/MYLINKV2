//copilot build
import React, { useState } from 'react';
import { IonIcon, IonPage, IonMenuButton, IonContent, IonHeader, IonToolbar, IonTitle, IonInput, IonItem, IonLabel, IonButton, IonGrid, IonRow, IonCol, IonAlert, IonButtons } from "@ionic/react";
import ReCAPTCHA from "react-google-recaptcha";
import { useHistory } from "react-router-dom";
import axios from 'axios'; // Import Axios
import "./Login.css"; // Import CSS for styling
import '../theme/customcolors.css';
import { analyticsSharp, homeSharp, peopleSharp } from 'ionicons/icons';


const Login: React.FC = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleLogin = async () => {
    try {
      //fetchData();
      const response = await axios.get('https://www.590team1.info/userlist.json');
      const userList = response.data;
      console.log(response.data);
      //const myArr = JSON.parse(userList);
      //console.log(myArr);	    
      //const firstRecord = getFirstRecord(myArr);
      //console.log(firstRecord);
      //const jsUsers = JSON.parse(userList);
      //alert(firstRecord);
      const user = userList.find((u: { username: string; password: string; }) => u.username === username && u.password === password);

      if (user) {
        alert('Login successful!');
      } else {
        setError('Invalid username or password');
      }
    } catch (err) {
      console.error(err);
      setError('An error occurred while fetching the user list');
    }
  };
function getFirstRecord(jsonArray) {
  if (jsonArray.length > 0) {
    return jsonArray[1];
  } else {
    return null; // or handle the empty array case as needed
  }
}

// Usage
	
const fetchData = async () => {

  try {
    const response = await axios.get('https://www.590team1.info/userlist.json');
    console.log(response.data);
	
  } catch (error) {
    console.error('Error fetching data:', error);
  }
  
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
        <IonItem>
          <IonLabel position="stacked">Username</IonLabel>
          <IonInput value={username} onIonChange={e => setUsername(e.detail.value!)}></IonInput>
        </IonItem>
        <IonItem>
          <IonLabel position="stacked">Password</IonLabel>
          <IonInput type="password" value={password} onIonChange={e => setPassword(e.detail.value!)}></IonInput>
        </IonItem>
        <IonButton expand="block" onClick={handleLogin}>Login</IonButton>
        {error && <p style={{ color: 'red' }}>{error}</p>}
      </IonContent>
    </IonPage>
  );
};

export default Login;
