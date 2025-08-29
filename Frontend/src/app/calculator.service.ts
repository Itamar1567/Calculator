import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CalculatorService {
  async getAnswer(input: string): Promise<any> {
    try {

      var response = await fetch('http://localhost:5085/operations', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ input })
      });

      return await response.json();

    } catch (err) {
      console.error('Could not fetch: ' + err);
    }
  }
}
