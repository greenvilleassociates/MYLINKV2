import React, { useState } from "react";
import { 
  IonContent, IonIcon, IonHeader, IonPage, IonTitle, IonToolbar, IonInput, 
  IonItem, IonButton, IonLoading, IonGrid, IonRow, IonCol, IonAlert, 
  IonLabel, IonCard, IonCardContent, IonCardHeader, IonMenuButton, IonButtons
} from "@ionic/react";
import './ForgotPasswordprev.css';
import '../theme/customcolors.css';
import { homeSharp, heart, peopleSharp, flagSharp } from 'ionicons/icons';


const ForgotPassword: React.FC = () => {
  const [email, setEmail] = useState(""); // Stores the email entered by the user
  const [loading, setLoading] = useState(false); // Shows a loading indicator during request simulation
  const [alertMessage, setAlertMessage] = useState(""); // Stores the message shown in alerts
  const [showAlert, setShowAlert] = useState(false); // Controls visibility of the alert pop-up 
  
  // ✅ Email validation regex
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

  // Handle Password Reset Simulation
  const handleResetPassword = () => {
    if (!email.trim()) {
      setAlertMessage("⚠ Please enter a valid email address.");
      setShowAlert(true);
      return;
    }

    // ✅ Check if the email format is valid
    if (!emailRegex.test(email)) {
        setAlertMessage("❌ Invalid email format. Please enter a valid email.");
        setShowAlert(true);
        return;
      }

    setLoading(true); // Show loading indicator

    // Simulate an API response delay (2 seconds)
    setTimeout(() => {
      setLoading(false); // Hide loading indicator
      setAlertMessage("✅ A password reset link has been sent to your email.");
      setShowAlert(true);
      setEmail(""); // Clear input field after request
    }, 2000);
  };

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
	   <IonButton routerLink="/Profile"> 
		<IonIcon slot="icon-only" icon={peopleSharp}></IonIcon>
	    </IonButton>
          </IonButtons>
          <IonTitle text-right>@Identity.Manager</IonTitle>
        </IonToolbar>
      </IonHeader>

      <IonContent className="ion-padding forgot-password-page">
        <IonGrid className="ion-text-center">
          <IonRow className="ion-justify-content-center">
            <IonCol size="12" size-md="6">
              <IonCard className="login-card">
                <IonCardHeader>
                  <h2 className="ion-text-center">Reset Your Password</h2>
                </IonCardHeader>

                <IonCardContent>
                  <p className="ion-text-center">Enter your email address below, and we'll send you a link to reset your password.</p>

                  <IonItem className="ion-margin-bottom">
                    <IonLabel position="floating">Email Address</IonLabel>
                    <IonInput
                      type="email"
                      value={email}
                      onIonChange={(e) => setEmail(e.detail.value!)}
                      required
                    />
                  </IonItem>

                  <IonButton
                    expand="full"
                    className="ion-margin-top"
                    onClick={handleResetPassword}
                    disabled={loading}
                  >
                    Send Reset Link
                  </IonButton>

                  <IonButton expand="full" fill="clear" routerLink="/login" className="back-to-login-btn">
                    Back to Login
                  </IonButton>
                </IonCardContent>
              </IonCard>
            </IonCol>
          </IonRow>
        </IonGrid>

        <IonLoading isOpen={loading} message="Processing request..." />

        <IonAlert
          isOpen={showAlert}
          onDidDismiss={() => setShowAlert(false)}
          header="Notification"
          message={alertMessage}
          buttons={["OK"]}
        />
      </IonContent>
    </IonPage>
  );
};

export default ForgotPassword;
