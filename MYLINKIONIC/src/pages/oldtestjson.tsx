import React, { useEffect, useState } from 'react';
import { IonApp, IonHeader, IonTitle, IonToolbar, IonContent, IonList, IonItem } from '@ionic/react';
import axios from 'axios';
import '../theme/customcolors.css';

const TestJson: React.FC = () => {
  const [users, setUsers] = useState<any[]>([]);

  useEffect(() => {
    axios.get('/userList.json')
      .then(response => {
        setUsers(response.data);
      })
      .catch(error => {
        console.error('Error fetching the user list:', error);
      });
  }, []);

  return (
    <IonApp>
      <IonHeader>
        <IonToolbar color="danger">
          <IonTitle>User List</IonTitle>
        </IonToolbar>
      </IonHeader>
      <IonContent>
        <IonList>
          {users.map(user => (
            <IonItem key={user.id}>
              {user.name} - {user.email}
            </IonItem>
          ))}
        </IonList>
      </IonContent>
    </IonApp>
  );
};

export default TestJson;

