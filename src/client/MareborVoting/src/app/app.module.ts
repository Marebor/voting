import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CandidatesListComponent } from './components/candidates-list/candidates-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { VotersListComponent } from './components/voters-list/voters-list.component';
import { VotingComponent } from './components/voting/voting.component';

@NgModule({
  declarations: [
    AppComponent,
    CandidatesListComponent,
    VotersListComponent,
    VotingComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }