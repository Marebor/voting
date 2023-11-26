import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AppConfigService } from "./app-config.service";
import { ApiService } from "./api.service";
import { CommandResult } from "../models/command-result.model";

@Injectable({
    providedIn: 'root'
})
export class VotingService {

    constructor(private appConfigService: AppConfigService, private apiService: ApiService) { }

    vote(voterName: string, candidateName: string): Observable<CommandResult> {
        return this.apiService.sendCommand(`${this.appConfigService.apiUrl}/votes`, { voterName, candidateName });
    }
}