import React, { useState } from 'react';
import { IonButton, IonContent, IonInput, IonItem, IonLabel, IonPage, IonToast } from '@ionic/react';

const JLogin: React.FC = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [showToast, setShowToast] = useState(false);
  const [toastMessage, setToastMessage] = useState('');

  const handleLogin = async () => {
    const url = 'https://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/api/Users';

    try {
      const response = await fetch(url);

      if (response.ok) {
        const users = await response.json(); // Assume the response is an array of user objects
        const match = users.find(
          (user: { username: string; password: string }) =>
            user.username === username && user.password === password
        );

        if (match) {
          setToastMessage('Login successful!');
        } else {
          setToastMessage('Invalid credentials. Please try again.');
        }
      } else {
        setToastMessage('Error fetching user data.');
      }
    } catch (error) {
      setToastMessage('Error connecting to the server.');
      console.error('Error:', error);
    }

    setShowToast(true);
  };

  return (
    <IonPage>
      <IonContent className="ion-padding">
        <IonItem>
          <IonLabel position="floating">Username</IonLabel>
          <IonInput
            value={username}
            onIonChange={(e: any) => setUsername(e.target.value)}
          ></IonInput>
        </IonItem>
        <IonItem>
          <IonLabel position="floating">Password</IonLabel>
          <IonInput
            type="password"
            value={password}
            onIonChange={(e: any) => setPassword(e.target.value)}
          ></IonInput>
        </IonItem>
        <IonButton expand="block" onClick={handleLogin}>
          Login
        </IonButton>
        <IonToast
          isOpen={showToast}
          message={toastMessage}
          duration={2000}
          onDidDismiss={() => setShowToast(false)}
        />
      </IonContent>
    </IonPage>
  );
};

export default JLogin;
