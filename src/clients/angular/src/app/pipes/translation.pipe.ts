import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'mlt' // Multi language text
})
export class TranslationPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return "ok";
  }

}
