import { VideoplayerComponent } from './videoplayer/videoplayer.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FavouriteComponent } from './favourite/favourite.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent} from './login/login.component';
//import { RegistrationComponent } from './registration/registration.component';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component'
import {ForgetPasswordComponent} from './forget-password/forget-password.component'
import {AuthGuardService} from './Services/auth-guard.service'

const routes: Routes = [
  {path:"",redirectTo:'home', pathMatch: 'full' },
  //{path:"registration",component:RegistrationComponent},
  {path:"login",component:LoginComponent},
  {path:"reset-password",component: ResetPasswordComponent,canActivate: [AuthGuardService]},
  {path:"forgot-password",component: ForgetPasswordComponent},
  {path:"home",component:HomeComponent,canActivate: [AuthGuardService]},
  {path:"userprofile",component:UserprofileComponent,canActivate: [AuthGuardService]},
  {path:"fav",component:FavouriteComponent,canActivate: [AuthGuardService]},
  {path:"videoplayer",component:VideoplayerComponent},
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
