import { Component, OnInit } from '@angular/core';
import { VoterService } from '../../services/voter.service';
import { Voter } from '../../models/voter.model';
import { NotificationService } from '../../services/notification.service';
import { VoterAdded } from '../../models/notifications/voter-added.model';
import { VoteAdded } from '../../models/notifications/vote-added.model';
import { CommandResult } from '../../models/command-result.model';

@Component({
  selector: 'app-voters-list',
  templateUrl: './voters-list.component.html',
  styleUrl: './voters-list.component.scss',
})
export class VotersListComponent implements OnInit {
  
  voters: Voter[] | undefined;
  newVoterName: string | undefined;
  addingNewVoter = false;
  addVoterCommandResult: CommandResult | undefined;

  constructor(private voterService: VoterService, private notificationService: NotificationService) {}

  ngOnInit() {
    this.voterService.getVoters().subscribe(voters => this.voters = voters);
    this.notificationService.notification<VoterAdded>('VoterAdded').subscribe(notification => {
      this.voters?.push({ name: notification.name, hasVoted: false });
    });
    this.notificationService.notification<VoteAdded>('VoteAdded').subscribe(notification => {
      const voter = this.voters?.find(Voter => Voter.name === notification.voterName);
      
      if (voter) {
        voter.hasVoted = true;
      }
    });
  }

  onModalOpened() {
    this.addVoterCommandResult = undefined;
    this.newVoterName = undefined;
  }

  addVoter() {
    this.addingNewVoter = true;
    this.addVoterCommandResult = undefined;

    this.voterService.addVoter(this.newVoterName!).subscribe(commandResult => {
      this.addingNewVoter = false;
      this.addVoterCommandResult = commandResult;
    });
  }
}