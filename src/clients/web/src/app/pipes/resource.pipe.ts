import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'resource'
})
export class ResourcePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return "ok";
  }

}
