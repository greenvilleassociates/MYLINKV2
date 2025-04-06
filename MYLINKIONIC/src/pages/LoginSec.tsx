import { IonButtons, IonIcon, IonContent, IonHeader, IonBackButton, IonMenuButton, IonPage, IonTitle, IonToolbar, IonAlert, IonCard, IonButton } from '@ionic/react';
import { useParams } from 'react-router';
import '../theme/customcolors.css';
import '../pages/LoginSec.css';
import Iframe from 'react-iframe';
import { homeSharp, heart, peopleSharp, flagSharp } from 'ionicons/icons';

const LoginSec: React.FC = () => {

  const { name } = useParams<{ name: string; }>();

  return (
    <IonPage>
	
      <IonHeader>
        <IonToolbar color = "danger">
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
          <IonTitle text-right>CockyEnterprises - Identity Security</IonTitle>
        </IonToolbar>
      </IonHeader>

      <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar color = "danger"><IonTitle>CockyEntertainment - Identity Security</IonTitle>
           </IonToolbar>
        </IonHeader>
        <Iframe url="https://www.590team1.info/loginsec.html"
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

export default LoginSec;
