import {
  IonImg,
  IonCard,
  IonHeader,
  IonContent,
  IonToolbar,
  IonIcon,
  IonItem,
  IonLabel,
  IonList,
  IonListHeader,
  IonMenu,
  IonMenuToggle,
  IonNote,
} from '@ionic/react';

import { useLocation } from 'react-router-dom';
import { roseSharp,librarySharp, readerSharp, receiptSharp, cellularSharp, medalSharp, constructSharp, newspaperSharp, globeSharp, businessSharp, bodySharp, archiveOutline, archiveSharp, bookmarkOutline, heartOutline, heartSharp, mailOutline, mailSharp, paperPlaneOutline, paperPlaneSharp, trashOutline, trashSharp, warningOutline, warningSharp } from 'ionicons/icons';
import './Menu.css';
import Login from '../pages/Login';
import Home from '../pages/Home';
import CertManager from '../pages/CertManager';
import MyCerts from '../pages/MyCerts';
import TestJson from '../pages/testjson';
import '../theme/customcolors.css';

interface AppPage {
  url: string;
  iosIcon: string;
  mdIcon: string;
  title: string;
}

const appPages: AppPage[] = [
  {
    title: 'Identity',
    url: 'Login',
    iosIcon: mailOutline,
    mdIcon: bodySharp
  },
  {
    title: 'CE.Home',
    url: 'Home',
    iosIcon: mailOutline,
    mdIcon: businessSharp
  },
  {
    title: 'CE.About',
    url: 'About',
    iosIcon: mailOutline,
    mdIcon: globeSharp
  },
   {
    title: 'CE.Learn',
    url: 'CELearn',
    iosIcon: mailOutline,
    mdIcon: medalSharp
  },
    {
    title: 'CE.Catalogue',
    url: 'CertCat',
    iosIcon: mailOutline,
    mdIcon: librarySharp
  },
    {
    title: 'CE.MyCertifications',
    url: 'MyCerts',
    iosIcon: mailOutline,
    mdIcon: newspaperSharp
  },
{
    title: 'CE.SiteManager',
    url: 'CertManager',
    iosIcon: mailOutline,
    mdIcon: cellularSharp
  },
{
    title: 'CE.Utilities',
    url: 'Welcome',
    iosIcon: mailOutline,
    mdIcon: roseSharp
  }
];

const labels = ['https://www.590team1.info', 'http://manager.590team1.info', 'https://manager2.590team1.info', 'https://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/WeatherForecast']; 

const Menu: React.FC = () => {
  const location = useLocation();
  const SMS = "SMS: 910.867.5309";

  return (
      <IonMenu contentId="main" type="overlay" class="ion-menu">
      <IonHeader><IonToolbar color="success"><IonLabel class="menuheader">My.Link V1.28 Black</IonLabel></IonToolbar></IonHeader>
      <IonContent>
	 <IonImg
      src="https://docs-demo.ionic.io/assets/madison.jpg"
      alt="The Wisconsin State Capitol building in Madison, WI at night"
    ></IonImg>

      <IonList id="inbox-list">
          {appPages.map((appPage, index) => {
            return (
              <IonMenuToggle key={index} autoHide={false}>
                <IonItem className={location.pathname === appPage.url ? 'selected' : ''} routerLink={appPage.url} routerDirection="none" lines="none" detail={false}>
                  <IonIcon aria-hidden="true" slot="start" ios={appPage.iosIcon} md={appPage.mdIcon} />
                  <IonLabel>{appPage.title}</IonLabel>
                </IonItem>
              </IonMenuToggle>
            );
          })}
        </IonList>

<IonList id="labels-list">
          <IonListHeader slot="center" class="centerlinks">QuickLinks</IonListHeader>
          {labels.map((label, index) => (
            
            <IonItem lines="none" key={index} href={label} target="_blank" class="linksmall">
              <IonIcon aria-hidden="true" slot="start" icon={bookmarkOutline} />
              <IonLabel>{index}-{label}</IonLabel>
             </IonItem>





          ))}
        </IonList>
      </IonContent>
    </IonMenu>
  );
};

export default Menu;
