import {Routes} from '@angular/router';
import {SubastaComponent} from './pages/subasta/subasta.component';
import {DetailsComponent} from '../app/pages/details/details.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';

const routeConfig: Routes = [
    {
      path: '',
      component: SubastaComponent,
      title: 'Subasta page',
    },
    {
      path: 'details/:id',
      component: DetailsComponent,
      title: 'Subasta details',
    },
    {
      path: '**',
      component: PageNotFoundComponent,
    },
  ];
  export default routeConfig;