import { Component, OnInit } from '@angular/core';
import { CandidateService } from '../../services/candidate.service';
import { Candidate } from '../../models/candidate.model';
import { NotificationService } from '../../services/notification.service';
import { CandidateAdded } from '../../models/notifications/candidate-added.model';
import { VoterAdded } from '../../models/notifications/voter-added.model';
import { CommandResult } from '../../models/command-result.model';
import { VoterService } from '../../services/voter.service';
import { Voter } from '../../models/voter.model';
import { VotingService } from '../../services/voting.service';

@Component({
  selector: 'app-voting',
  templateUrl: './voting.component.html',
  styleUrl: './voting.component.scss',
})
export class VotingComponent implements OnInit {
  
  candidates: Candidate[] | undefined;
  voters: Voter[] | undefined;
  selectedCandidateName: string | undefined;
  selectedVoterName: string | undefined;
  addingVote = false;
  addVoteCommandResult: CommandResult | undefined;

  constructor(
    private candidateService: CandidateService, 
    private voterService: VoterService, 
    private votingService: VotingService,
    private notificationService: NotificationService) {}

  ngOnInit() {
    this.candidateService.getCandidates().subscribe(candidates => this.candidates = candidates);
    this.voterService.getVoters().subscribe(voters => this.voters = voters);
    this.notificationService.notification<CandidateAdded>('CandidateAdded').subscribe(notification => {
      this.candidates?.push({ name: notification.name, votesCount: 0 });
    });
    this.notificationService.notification<VoterAdded>('VoterAdded').subscribe(notification => {
      this.voters?.push({ name: notification.name, hasVoted: false });
    });
  }

  vote() {
    this.addingVote = true;
    this.addVoteCommandResult = undefined;

    this.votingService.vote(this.selectedVoterName!, this.selectedCandidateName!).subscribe(commandResult => {
      this.addingVote = false;
      this.addVoteCommandResult = commandResult;
    });
  }
}