import {
  IonContent,
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
import { helpSharp, librarySharp, readerSharp, receiptSharp, cellularSharp, medalSharp, constructSharp, newspaperSharp, globeSharp, businessSharp, bodySharp, archiveOutline, archiveSharp, bookmarkOutline, heartOutline, heartSharp, mailOutline, mailSharp, paperPlaneOutline, paperPlaneSharp, trashOutline, trashSharp, warningOutline, warningSharp } from 'ionicons/icons';
import './Menu.css';
import Login from '../pages/Login';
import Home from '../pages/Home';
import Help from '../pages/Help';
import CertManager from '../pages/CertManager';
import MyCerts from '../pages/MyCerts';
import TestJson from '../pages/testjson';

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
    title: 'Mail',
    url: 'Mail',
    iosIcon: mailOutline,
    mdIcon: mailSharp
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
    title: 'MyTraining',
    url: 'MyTraining',
    iosIcon: mailOutline,
    mdIcon: receiptSharp
  },
   {
    title: 'MyResume',
    url: 'MyResume',
    iosIcon: mailOutline,
    mdIcon: readerSharp
  },
    {
    title: 'CE.Learn',
    url: 'CELearn',
    iosIcon: mailOutline,
    mdIcon: medalSharp
  },
 {
    title: 'Utilities',
    url: 'Welcome',
    iosIcon: mailOutline,
    mdIcon: constructSharp
  },
{
    title: 'SiteManager',
    url: 'CertManager',
    iosIcon: mailOutline,
    mdIcon: cellularSharp
  },
{
    title: 'Help',
    url: 'Help',
    iosIcon: mailOutline,
    mdIcon: helpSharp
  },
];

const labels = ['https://www.590team1.info', 'https://api.590team1.info', 'https://manager2.590team1.info', 'https://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/WeatherForecast', 'https://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/api/Users'];

const Menu: React.FC = () => {
  const location = useLocation();

  return (
    <IonMenu contentId="main" type="overlay">
     <IonHeader color="dark">CockyEnterprises MyLink V2.0</IonHeader>
      <IonContent>
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
