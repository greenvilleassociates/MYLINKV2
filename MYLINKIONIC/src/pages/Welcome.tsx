import { IonButtons, IonIcon, IonContent, IonHeader, IonMenuButton, IonPage, IonTitle, IonToolbar, IonAlert, IonCard, IonButton } from '@ionic/react';
import { useParams } from 'react-router';
import '../theme/customcolors.css';
import { roseSharp, helpSharp, analyticsSharp, homeSharp, peopleSharp } from 'ionicons/icons';
import '../pages/Mail.css';
import Iframe from 'react-iframe';

const Welcome: React.FC = () => {

  const { name } = useParams<{ name: string; }>();

  return (
    <IonPage>
	
      <IonHeader>
        <IonToolbar color = "dark">
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
          <IonTitle text-right>@Utilities</IonTitle>
        </IonToolbar>
      </IonHeader>

      <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar color = "danger"><IonTitle>CockyEnterprises - Welcome</IonTitle>
           </IonToolbar>
        </IonHeader>
        <Iframe url="https://www.590team1.info/interiorindex.html"
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

export default Welcome;
