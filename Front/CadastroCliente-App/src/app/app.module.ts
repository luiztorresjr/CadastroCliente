import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListaClientesComponent } from './lista-clientes/lista-clientes.component';
import { EndpointService } from './services/endpoint.service';

@NgModule({
  declarations: [
    AppComponent,
    ListaClientesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [EndpointService],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
