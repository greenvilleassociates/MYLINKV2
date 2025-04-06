import { IonButtons, IonContent, IonHeader, IonMenuButton, IonPage, IonTitle, IonToolbar, IonAlert, IonCard, IonButton } from '@ionic/react';
import { useParams } from 'react-router';
import '../theme/customcolors.css';
import '../pages/CELearn.css';
import Iframe from 'react-iframe';

const TestJson: React.FC = () => {

  const { name } = useParams<{ name: string; }>();

  return (
    <IonPage>
	
      <IonHeader>
        <IonToolbar color = "danger">
          <IonButtons slot="start">
            <IonMenuButton />
          </IonButtons>
          <IonTitle text-right>CockyEnterprises - TestJson</IonTitle>
        </IonToolbar>
      </IonHeader>

      <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar color = "danger"><IonTitle>CockyEnterprises - TestJson</IonTitle>
           </IonToolbar>
        </IonHeader>
        <Iframe url="https://www.590team1.info/testjson.html"
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

export default TestJson;
