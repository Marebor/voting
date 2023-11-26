import { Component, OnInit } from '@angular/core';
import { CandidateService } from '../../services/candidate.service';
import { Candidate } from '../../models/candidate.model';
import { NotificationService } from '../../services/notification.service';
import { CandidateAdded } from '../../models/notifications/candidate-added.model';
import { VoteAdded } from '../../models/notifications/vote-added.model';
import { CommandResult } from '../../models/command-result.model';

@Component({
  selector: 'app-candidates-list',
  templateUrl: './candidates-list.component.html',
  styleUrl: './candidates-list.component.scss',
})
export class CandidatesListComponent implements OnInit {
  
  candidates: Candidate[] | undefined;
  newCandidateName: string | undefined;
  addingNewCandidate = false;
  addCandidateCommandResult: CommandResult | undefined;

  constructor(private candidateService: CandidateService, private notificationService: NotificationService) {}

  ngOnInit() {
    this.candidateService.getCandidates().subscribe(candidates => this.candidates = candidates);
    this.notificationService.notification<CandidateAdded>('CandidateAdded').subscribe(notification => {
      this.candidates?.push({ name: notification.name, votesCount: 0 });
    });
    this.notificationService.notification<VoteAdded>('VoteAdded').subscribe(notification => {
      const candidate = this.candidates?.find(candidate => candidate.name === notification.candidateName);
      
      if (candidate) {
        candidate.votesCount++;
      }
    });
  }

  onModalOpened() {
    this.addCandidateCommandResult = undefined;
    this.newCandidateName = undefined;
  }

  addCandidate() {
    this.addingNewCandidate = true;
    this.addCandidateCommandResult = undefined;

    this.candidateService.addCandidate(this.newCandidateName!).subscribe(commandResult => {
      this.addingNewCandidate = false;
      this.addCandidateCommandResult = commandResult;
    });
  }
}