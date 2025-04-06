import {
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
import { roseSharp, librarySharp, readerSharp, receiptSharp, cellularSharp, medalSharp, constructSharp, newspaperSharp, globeSharp, businessSharp, bodySharp, archiveOutline, archiveSharp, bookmarkOutline, heartOutline, heartSharp, mailOutline, mailSharp, paperPlaneOutline, paperPlaneSharp, trashOutline, trashSharp, warningOutline, warningSharp } from 'ionicons/icons';
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
    title: 'Home',
    url: 'Home',
    iosIcon: mailOutline,
    mdIcon: businessSharp
  },
  {
    title: 'About',
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
    title: 'CertificateCatalogue',
    url: 'CertCat',
    iosIcon: mailOutline,
    mdIcon: librarySharp
  },
    {
    title: 'MyCertifications',
    url: 'MyCerts',
    iosIcon: mailOutline,
    mdIcon: newspaperSharp
  },
{
    title: 'SiteManager',
    url: 'CertManager',
    iosIcon: mailOutline,
    mdIcon: cellularSharp
  }
];

const labels = ['https://www.590team1.info', 'http://manager.590team1.info', 'https://manager2.590team1.info', 'https://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/WeatherForecast'];
const labelname = ['WWWRoot', 'CampusManager', 'PublicManager', 'WeatherController'];

const Menu: React.FC = () => {
  const location = useLocation();

  return (
    <IonMenu contentId="main" type="overlay">
      <IonToolbar color="dark"><IonLabel class="menuheader">MY.Link V1.20 Black</IonLabel></IonToolbar>
      <IonContent>
        <IonList id="inbox-list">
          {/*<IonListHeader>CockyEnterprises.MyLink</IonListHeader>
          <IonNote>Version 1.09.Black</IonNote>*/}
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
            
            <IonItem lines="none" key={index} href={label} target="_blank" className="linksmall">
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
