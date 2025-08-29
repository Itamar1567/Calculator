import { Component, inject, ChangeDetectorRef } from '@angular/core';
import { CalculatorService } from '../calculator.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  imports: [FormsModule],
  template: `
    <section class="main">
      <h1> Welcome to Calculator </h1>
      <input type="text" placeholder="Type your equation" (keydown.enter)="onEnter()" [(ngModel)]="input"/>
      <h2>{{answer}}</h2>
    </section>
  `,
  styleUrl: './home.component.css'
})
export class HomeComponent {
  
  input: string = "1 + 1";
  answer: number = 0;
  calcService: CalculatorService = inject(CalculatorService);
  private detector: ChangeDetectorRef = inject(ChangeDetectorRef);


  async onEnter(): Promise<any>{

    try{
        var data = await this.calcService.getAnswer(this.input);
        this.answer = data.sum;
        this.detector.detectChanges();
    }
    catch(err){
      console.error("Could not retrieve data: ", err);
    }

    

  }



}
