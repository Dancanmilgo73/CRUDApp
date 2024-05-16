# Stage 1: Build Angular app
FROM node:20.11.1-alpine AS base
WORKDIR /app
RUN npm cache clean --force
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Stage 2: Serve with Nginx
FROM nginx:stable
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=base /app/dist/frontend/browser /usr/share/nginx/html
EXPOSE 80
# CMD ["nginx", "-g", "daemon off;"]
