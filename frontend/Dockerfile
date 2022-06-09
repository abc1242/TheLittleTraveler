FROM node:lts-alpine3.14

WORKDIR /frontend

COPY ./package.json /frontend

RUN npm install

COPY . /frontend

RUN npm run build

CMD ["npx", "serve", "-s", "build"]

EXPOSE 3000