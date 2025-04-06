import React, { useState } from 'react';
import { IonIcon, IonPage, IonMenuButton, IonContent, IonHeader, IonToolbar, IonTitle, IonInput, IonItem, IonLabel, IonButton, IonGrid, IonRow, IonCol, IonAlert, IonButtons } from "@ionic/react";
import $ from 'jquery';
import './LoginJquery.css'; // Create this CSS file for custom styles
import '../theme/customcolors.css';
import { roseSharp, helpSharp, analyticsSharp, homeSharp, peopleSharp } from 'ionicons/icons';

const LoginJquery: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [message, setMessage] = useState('');

    const handleLogin = () => {
        $.ajax({
            url: 'https://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/api/Users',
            type: 'GET',
            success: function(response) {
                const user = response.find((user: any) => user.username === username && user.password === password);
                if (user) {
                    setMessage('Login successful!');
                } else {
                    setMessage('Invalid username or password.');
                }
            },
            error: function(xhr, status, error) {
                console.error('Error:', error);
                setMessage('Error: ' + error);
            }
        });
    };

    return (
        <IonPage class="login-page">
            <IonHeader>
                <IonToolbar color="dark">
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
                    <IonTitle>JqueryLogin</IonTitle>
                </IonToolbar>
            </IonHeader>
            <IonContent className="ion-padding login-page">
                <div className="login-container">
                    <IonItem>
                        <IonLabel position="floating">Username</IonLabel>
                        <IonInput value={username} onIonChange={e => setUsername(e.detail.value!)} />
                    </IonItem>
                    <IonItem>
                        <IonLabel position="floating">Password</IonLabel>
                        <IonInput type="password" value={password} onIonChange={e => setPassword(e.detail.value!)} />
                    </IonItem>
                    <IonButton expand="full" onClick={handleLogin}>Login</IonButton>
                    {message && <IonText color="danger"><p>{message}</p></IonText>}
                </div>
            </IonContent>
        </IonPage>
    );
};

export default LoginJquery;