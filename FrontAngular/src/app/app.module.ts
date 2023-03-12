import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';

import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastModule } from 'primeng/toast';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SidebarModule } from 'primeng/sidebar';
import { HomeComponent } from './home/home.component';
import { GameComponent } from './game/game.component';
import { PreparationComponent } from './preparation/preparation.component';
import { ShootGameComponent } from './shoot-game/shoot-game.component';
import { FinComponent } from './fin/fin.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GameComponent,
    PreparationComponent,
    ShootGameComponent,
    FinComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ProgressSpinnerModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    MessagesModule,
    MessageModule,
    BrowserAnimationsModule,
    ToastModule,
    NgbModule,
    SidebarModule,
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
