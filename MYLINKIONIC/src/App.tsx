import { IonApp, IonRouterOutlet, IonSplitPane, setupIonicReact } from '@ionic/react';
import { IonReactRouter } from '@ionic/react-router';
import { Redirect, Route } from 'react-router-dom';
import Menu from './components/Menu';
import Page from './pages/Page';
import Login from './pages/Login';
import Welcome from './pages/Welcome';
import Home from './pages/Home';
import TestJson from './pages/testjson';
import TestAPI from './pages/testapi';
import CertManager from './pages/CertManager';
import MyTraining from './pages/MyTraining';
import MyResume from './pages/MyResume';
import MyCerts from './pages/MyCerts';
import CertCat from './pages/CertCat';
import LoggedIn from './pages/LoggedIn';
import About from './pages/About';
import Profile from './pages/Profile';
import Register from './pages/Register';
import Mail from './pages/Mail';
import ForgotPassword from './pages/ForgotPassword';
import CELearn from './pages/CELearn';
import LoginSec from './pages/LoginSec';
import Help from './pages/Help';
import JLogin from './pages/JLogin';
import MyCerts2 from './pages/MyCerts2';
import LoggedIn3 from './pages/LoggedIn3';
import AccessLogs from './pages/AccessLogs';
import ResetPassword from './pages/ResetPassword';
import AdminHome from './pages/AdminHome';
import LoginJquery from './pages/LoginJquery';
import LogOut from './pages/LogOut';

/* Core CSS required for Ionic components to work properly */
import '@ionic/react/css/core.css';

/* Basic CSS for apps built with Ionic */
import '@ionic/react/css/normalize.css';
import '@ionic/react/css/structure.css';
import '@ionic/react/css/typography.css';

/* Optional CSS utils that can be commented out */
import '@ionic/react/css/padding.css';
import '@ionic/react/css/float-elements.css';
import '@ionic/react/css/text-alignment.css';
import '@ionic/react/css/text-transformation.css';
import '@ionic/react/css/flex-utils.css';
import '@ionic/react/css/display.css';

/**
 * Ionic Dark Mode
 * -----------------------------------------------------
 * For more info, please see:
 * https://ionicframework.com/docs/theming/dark-mode
 */

/* import '@ionic/react/css/palettes/dark.always.css'; */
/* import '@ionic/react/css/palettes/dark.class.css'; */
import '@ionic/react/css/palettes/dark.system.css';

/* Theme variables */
import './theme/variables.css';

setupIonicReact();

const App: React.FC = () => {
  return (
    <IonApp>
    <IonReactRouter>
      <IonSplitPane contentId="main">
        <Menu />
        <IonRouterOutlet id="main">
          <Route exact path="/">
            <Login />
          </Route>
      
<Route exact path="/About" >
      <About />
</Route>
<Route exact path="/Mail" >
      <Mail />
</Route>
<Route path="/AdminHome">
      <AdminHome />
</Route>          
<Route path="/Login">
      <Login />
</Route>
<Route path="/LoginSec">
   <LoginSec />
</Route>
<Route path="/JLogin">
   <JLogin />
</Route>
<Route path="/LoggedIn3">
   <LoggedIn3 />
</Route>
<Route path="/Help">
   <Help />
</Route>
<Route path="/CertManager">
      <CertManager />
</Route>
<Route path="/MyCerts">
      <MyCerts />
</Route>
<Route path="/MyCerts">
      <MyCerts />
</Route>
<Route path="/MyTraining">
      <MyTraining />
</Route>
<Route path="/MyResume">
      <MyResume />
</Route>
<Route path="/Home">
      <Home />
</Route>
<Route path="/Register">
      <Register />
</Route>
<Route path="/ForgotPassword">
      <ForgotPassword />
</Route>
<Route path="/TestJson">
<TestJson />  
</Route>
<Route path="/CertCat">
<CertCat />  
</Route>          
<Route path="/TestAPI">
<TestAPI />  
</Route>
<Route path="/Profile">
<Profile />  
</Route>
<Route path="/LoginJquery">
<LoginJquery />  
</Route>
<Route path="/LoggedIn">
<LoggedIn />  
</Route>
<Route path="/Welcome">
<Welcome />  
</Route>
<Route path="/CELearn">
      <CELearn />
</Route>
<Route path="/LogOut">
      <LogOut />
</Route>
<Route path="/AccessLogs">
<AccessLogs />  
</Route>
<Route path="/ResetPassword">
      <ResetPassword />
</Route>
<Route path="/folder/:name" exact={true}>
            <Page />
          </Route>
        </IonRouterOutlet>
      </IonSplitPane>
    </IonReactRouter>
  </IonApp>

  );
};

export default App;

