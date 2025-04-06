import React, { useState } from "react";
import { IonContent, IonHeader, IonPage, IonTitle, IonToolbar, IonInput, IonItem, IonButton, IonLoading, IonGrid, IonRow, IonCol, IonAlert, IonLabel, IonCard, IonCardContent, IonCardHeader } from "@ionic/react";
import axios from "axios";

const API_URL = "https://your-api.com/forgot-password"; // Replace with your actual backend API endpoint

const ForgotPassword: React.FC = () => {
  const [email, setEmail] = useState(""); // Stores the email entered by the user
  const [loading, setLoading] = useState(false); // Shows a loading indicator during API call
  const [alertMessage, setAlertMessage] = useState(""); // Stores the message shown in alerts
  const [showAlert, setShowAlert] = useState(false); // Controls visibility of the alert pop-up    

  // ✅ Email validation regex
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

  // Handle Password Reset API Request
  const handleResetPassword = async () => {
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

    setLoading(true);   // Show loading indicator
    setAlertMessage("");

    try {
      const response = await axios.post(API_URL, { email });

      if (response.data.success) {
        setAlertMessage("✅ A password reset link has been sent to your email.");
      } else {
        setAlertMessage(response.data.message || "❌ Failed to send reset link.");
      }
    } catch (error: any) {  // Fix: Define error type
        console.error("Error:", error); // Debugging
  
        setAlertMessage(
          error?.response?.data?.message || "⚠ An error occurred. Please try again."
        );
    } finally {
      setLoading(false); // Hide loading indicator
      setShowAlert(true); // Show response message
      setEmail(""); // Clear input field after request
    }
  };

  return (
    <IonPage>
      <IonHeader>
        <IonToolbar>
          <IonTitle>Forgot Password</IonTitle>
        </IonToolbar>
      </IonHeader>

      <IonContent className="ion-padding">
        <IonGrid className="ion-text-center">
          <IonRow className="ion-justify-content-center">
            <IonCol size="12" size-md="6">
              <IonCard>
                <IonCardHeader>
                  <h2>Reset Your Password</h2>
                </IonCardHeader>

                <IonCardContent>
                  <p>Enter your email address below, and we'll send you a link to reset your password.</p>

                  <IonItem>
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

                  <IonButton expand="full" fill="clear" routerLink="/login">
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
