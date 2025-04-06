import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { IonContent, IonHeader, IonPage, IonTitle, IonToolbar, IonList, IonItem, IonLabel } from '@ionic/react';
import '../theme/customcolors.css';

const TestApi: React.FC = () => {
  const [forecasts, setForecasts] = useState<any[]>([]);

  useEffect(() => {
    axios.get('https://api.590team1.info/WeatherForecast')
      .then(response => {
        setForecasts(response.data);
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }, []);

  return (
    <IonPage>
      <IonHeader>
        <IonToolbar color = "danger">
          <IonTitle>Weather Forecast</IonTitle>
        </IonToolbar>
      </IonHeader>
      <IonContent>
        <IonList>
          {forecasts.map((forecast, index) => (
            <IonItem key={index}>
              <IonLabel>
                <h2>{forecast.date}</h2>
                <p>Temperature: {forecast.temperatureC}°C</p>
                <p>Summary: {forecast.summary}</p>
              </IonLabel>
            </IonItem>
          ))}
        </IonList>
      </IonContent>
    </IonPage>
  );
};

export default TestApi
