import { IonButtons, IonContent, IonIcon, IonHeader, IonMenuButton, IonPage, IonTitle, IonToolbar, IonAlert, IonCard, IonButton } from '@ionic/react';
import { useParams } from 'react-router';
import '../theme/customcolors.css';
import '../pages/AdminHome.css';
import Iframe from 'react-iframe';
import { roseSharp, helpSharp, analyticsSharp, homeSharp, heart, peopleSharp, flagSharp } from 'ionicons/icons';

const AdminHome: React.FC = () => {

  const { name } = useParams<{ name: string; }>();

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
          <IonTitle text-right>@AdminHome</IonTitle>
        </IonToolbar>
      </IonHeader>

      <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar color = "danger"><IonTitle>@AdminHome</IonTitle>
           </IonToolbar>
        </IonHeader>
        <Iframe url="https://www.590team1.info/adminhome.html"
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

export default AdminHome;
